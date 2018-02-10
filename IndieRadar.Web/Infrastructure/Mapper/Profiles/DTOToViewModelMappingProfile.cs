using System;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class DTOToViewModelMappingProfile : Profile
    {
        public DTOToViewModelMappingProfile()
        {
            CreateMap<GameDTO, GameCardViewModel>()
                .ForMember(c => c.MainPhoto, d => d.MapFrom(c =>
                    $"data:image/png;base64,{Convert.ToBase64String(c.MainPhoto)}"));
            CreateMap<GenreDTO, GenreViewModel>();
            CreateMap<PlatformDTO, PlatformViewModel>();
        }
    }
}