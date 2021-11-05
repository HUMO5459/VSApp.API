using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSApp.Business.Models;
using VSApp.Core.Entities;

namespace VSApp.Business.Mappers
{
    public class IEMapper : Profile
    {
        public IEMapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Entering, EnteringModel>().ReverseMap();
            CreateMap<Exiting, ExitingModel>().ReverseMap();
            CreateMap<DevicesIP, DevicesIPModel>().ReverseMap();
        }
    }

    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensure that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<IEMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
