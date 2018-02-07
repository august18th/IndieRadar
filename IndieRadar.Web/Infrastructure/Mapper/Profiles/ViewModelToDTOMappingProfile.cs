using System;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<GameViewModel, GameDTO>();
            CreateMap<String, GamePlatformDTO>()
                .ForMember(c => c.PlatformId, g => g.MapFrom(r => r));
            CreateMap<String, GameGenreDTO>()
                .ForMember(c => c.GenreId, g => g.MapFrom(r => r));
            CreateMap<RegisterClientViewModel, UserDTO>();
            CreateMap<GenreViewModel, GenreDTO>();
            CreateMap<PlatformViewModel, PlatformDTO>();
        }
    }
}