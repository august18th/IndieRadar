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
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IGenreService _genreService;
        private readonly IPlatformService _platformService;
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService,
            IMapper mapper, IGenreService genreService, IPlatformService platformService)
        {
            _gameService = gameService;
            _genreService = genreService;
            _mapper = mapper;
            _platformService = platformService;
        }


        // GET: Games
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)
        {
            var games = _mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameCardViewModel>>
                (await _gameService.GetGamesAsync());
            GameCardListViewModel gameCardList = await CreateGameCardList(page, games.ToList());
            return View(gameCardList);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> FilterByGenre(string genreName, int page = 1)
        {
            var games = _mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameCardViewModel>>
                (await _gameService.GetGamesByGenreAsync(genreName));
            GameCardListViewModel gameCardList = await CreateGameCardList(page, games.ToList());
            return View("Index", gameCardList);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> FilterByPlatform(string platformName, int page = 1)
        {
            var games = _mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameCardViewModel>>
                (await _gameService.GetGamesByPlatformAsync(platformName));
            GameCardListViewModel gameCardList = await CreateGameCardList(page, games.ToList());
            return View("Index", gameCardList);
        }

        [NonAction]
        public async Task<GameCardListViewModel> CreateGameCardList(int page, IList<GameCardViewModel> games)
        {
            int pageSize = 10;
            var gameCards =
                games.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = games.Count
            };
            GameCardListViewModel gameCardList = new GameCardListViewModel
            {
                PageInfo = pageInfo,
                GameCards = gameCards.ToList(),
                FilterCriterias = await GetFilterCriterias()
            };
            return gameCardList;
        }

        [NonAction]
        public async Task<GameCriterias> GetFilterCriterias()
        {
            var genres =
                _mapper.Map<ICollection<GenreDTO>, ICollection<GenreViewModel>>(await _genreService.GetGenresAsync());
            var platforms =
                _mapper.Map<ICollection<PlatformDTO>, ICollection<PlatformViewModel>>(await _platformService.GetPlatformsAsync());

            return new GameCriterias { Genres = genres.ToList(), Platforms = platforms.ToList() };
        }
    }
}