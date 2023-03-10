using AutoMapper;
using WpfAppMvvmToolkit.API.Context.Entities;
using WpfAppMvvmToolkit.Core.Models;

namespace MyToDo.Api.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<WpfAppMvvmToolkit.API.Context.Entities.Profile, ProfileDto>().ReverseMap();

        }


    }
}
