using AutoMapper;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;

namespace IndieRadar.Web.Infrastructure.Mapper.Profiles
{
    public class DTOToDomainMappingProfile : Profile
    {
        public DTOToDomainMappingProfile()
        {
            CreateMap<GameDTO, Game>();
        }
    }
}