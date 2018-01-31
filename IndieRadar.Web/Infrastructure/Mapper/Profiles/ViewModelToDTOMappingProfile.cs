using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<GameCardViewModel, GameDTO>();
            CreateMap<RegisterClientViewModel, UserDTO>();
        }
    }
}