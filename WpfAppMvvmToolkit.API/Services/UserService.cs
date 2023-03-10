using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.API.Context.UnitOfWork;
using WpfAppMvvmToolkit.Core.Extensions;
using WpfAppMvvmToolkit.Core.Models;

namespace WpfAppMvvmToolkit.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork work;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork work, IMapper mapper)
        {
            this.work = work;
            this.mapper = mapper;
        }
        public async Task<ApiResponse> LoginAsync(string account, string password)
        {
            try
            {
                password = password.GetMD5();
                var model = await work.GetRepository<User>().GetFirstOrDefaultAsync(
                      predicate: x => x.Account!.Equals(account) && x.Password!.Equals(password));
                if (model == null)
                {
                    return new ApiResponse($"{Core.Properties.Strings.User}或{Core.Properties.Strings.Password}错误,请重试！");
                }
                return new ApiResponse(true, new UserInfo()
                {
                    Account = model.Account,
                    UserName = model.UserName,
                    Id = model.Id
                });

            }
            catch (Exception ex)
            {
                return new ApiResponse($"登录失败:{ex.Message}");
            }
        }

        public async Task<ApiResponse> Resgiter(UserInfo user)
        {
            try
            {
                var model = mapper.Map<User>(user);
                var repository = work.GetRepository<User>();

                var userModel = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account!.Equals(model.Account));

                if (userModel != null)
                    return new ApiResponse($"{Core.Properties.Strings.User}：{model.Account} 已经存在，请重新注册");

                model.CreateDate = DateTime.Now;
                model.Password = model.Password!.GetMD5();
                await repository.InsertAsync(model);
                if (await work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, model);
                return new ApiResponse($"{Core.Properties.Strings.User}注册失败，请重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse($"{Core.Properties.Strings.User}注册失败:{ex.Message}");
            }
        }

        public async Task<ApiResponse> UpdateAccount(UserInfo user)
        {
            try
            {
                var model = mapper.Map<User>(user);
                var repository = work.GetRepository<User>();
                var userModel = await repository.GetFirstOrDefaultAsync(predicate: x => x.Account!.Equals(model.Account), include: s => s.Include(x => x.UserData!));
                if (userModel == null)
                    return new ApiResponse($"未找到{Core.Properties.Strings.User}：{model.Account} ");
                userModel.UpdateDate = DateTime.Now;
                userModel.Password = model.Password!.GetMD5();
                userModel.UserData = model.UserData;
                repository.Update(userModel);
                if (await work.SaveChangesAsync() > 0)
                    return new ApiResponse(true, userModel);
                return new ApiResponse($"{Core.Properties.Strings.User}更新失败，请重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse($"{Core.Properties.Strings.User}更新失败:{ex.Message}");
            }

        }
    }
}
