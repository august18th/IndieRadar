using System;
using System.IO;
using System.Web;
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
                .ForMember(c => c.PlatformName, g => g.MapFrom(r => r));
            CreateMap<String, GameGenreDTO>()
                .ForMember(c => c.GenreName, g => g.MapFrom(r => r));
            CreateMap<HttpPostedFileBase, byte[]>()
                .ConstructUsing(fb =>
                {
                    MemoryStream target = new MemoryStream();
                    fb.InputStream.CopyTo(target);
                    return target.ToArray();
                });
            CreateMap<RegisterClientViewModel, UserDTO>();
            CreateMap<GenreViewModel, GenreDTO>();
            CreateMap<PlatformViewModel, PlatformDTO>();
        }
    }
}