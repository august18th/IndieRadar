using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class DTOToViewModelMappingProfile : Profile
    {
        public DTOToViewModelMappingProfile()
        {
            CreateMap<GameDTO, GameCardViewModel>();
            CreateMap<GenreDTO, GenreViewModel>();
            CreateMap<PlatformDTO, PlatformViewModel>();
        }
    }
}