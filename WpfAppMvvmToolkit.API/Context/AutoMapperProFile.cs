using AutoMapper;
using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.Core.Models;

namespace MyToDo.Api.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {

            CreateMap<User, UserInfo>().ReverseMap();
            CreateMap<UserData, UserInfoData>().ReverseMap();

        }


    }
}
