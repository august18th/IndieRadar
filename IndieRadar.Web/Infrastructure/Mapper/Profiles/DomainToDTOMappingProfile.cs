using AutoMapper;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Game, GameDTO>();
            CreateMap<ApplicationUser, UserDTO>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<Platform, PlatformDTO>();
        }
    }
}