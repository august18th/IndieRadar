using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IPlatformService _platformService;

        public AdminController(IGenreService genreService, IMapper mapper,
            IPlatformService platformService)
        {
            _genreService = genreService;
            _mapper = mapper;
            _platformService = platformService;
        }

        // GET: Admin
        [HttpGet]
        public async Task<ActionResult> AddGame()
        {
            var genres =
                _mapper.Map<ICollection<GenreDTO>, ICollection<GenreViewModel>>(await _genreService.GetGenresAsync());
            var platforms =
                _mapper.Map<ICollection<PlatformDTO>, ICollection<PlatformViewModel>>(await _platformService.GetPlatformsAsync());
            CreateGameViewModel createGame = new CreateGameViewModel
            {
                Genres = genres.ToList(),
                Platforms = platforms.ToList()
            };
            return View();
        }

        //[HttpPost]
        //public ActionResult AddGame()
        //{

        //}
    }
}