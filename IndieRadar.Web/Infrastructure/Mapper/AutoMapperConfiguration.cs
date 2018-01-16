using AutoMapper;
using IndieRadar.Web.Infrastructure.Mapper.Profiles;

namespace IndieRadar.Web.Infrastructure.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOToDomainMappingProfile());
                cfg.AddProfile(new ViewModelToDTOMappingProfile());
                cfg.AddProfile(new DTOToViewModelMappingProfile());
                cfg.AddProfile(new DomainToDTOMappingProfile());
            });
        }
    }
}