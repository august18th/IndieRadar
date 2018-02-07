using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;
using IndieRadar.Web.Models;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly IPlatformService _platformService;
        private readonly IGameService _gameService;

        public AdminController(IGenreService genreService, IMapper mapper,
            IPlatformService platformService, IGameService gameService)
        {
            _genreService = genreService;
            _mapper = mapper;
            _platformService = platformService;
            _gameService = gameService;
        }

        // GET: Admin
        [HttpGet]
        public async Task<ActionResult> AddGame()
        {
            CreateGameViewModel createGame = new CreateGameViewModel
            {
                GameCriterias = await GetGameCriterias()
            };
            return View(createGame);
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                var res = await _gameService.CreateGameAsync(_mapper.Map<GameViewModel, GameDTO>(game));
            }
            CreateGameViewModel createGame = new CreateGameViewModel
            {
                GameCriterias = await GetGameCriterias(),
                Game = game
            };
            return View(createGame);
        }

        [NonAction]
        public async Task<GameCriterias> GetGameCriterias()
        {
            var genres =
                _mapper.Map<ICollection<GenreDTO>, ICollection<GenreViewModel>>(await _genreService.GetGenresAsync());
            var platforms =
                _mapper.Map<ICollection<PlatformDTO>, ICollection<PlatformViewModel>>(await _platformService.GetPlatformsAsync());

            return new GameCriterias { Genres = genres.ToList(), Platforms = platforms.ToList() };
        }
    }
}