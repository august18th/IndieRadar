using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;
using IndieRadar.Web.Models;
using IndieRadar.Web.ModelsEnums;
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
        public async Task<ActionResult> Index(string genreName, string platformName,
            int page = 1, GamesSortOrder sortOrder = GamesSortOrder.ByDateAscending)
        {
            ICollection<GameCardViewModel> games = new List<GameCardViewModel>();
            if (genreName != null)
            {
                games = _mapper.Map<ICollection<GameDTO>, ICollection<GameCardViewModel>>
                    (await _gameService.GetGamesByGenreAsync(genreName));
            }

            if (platformName != null)
            {
                games = _mapper.Map<ICollection<GameDTO>, ICollection<GameCardViewModel>>
                    (await _gameService.GetGamesByPlatformAsync(platformName));
            }

            if (platformName == null && genreName == null)
            {
                games = _mapper.Map<ICollection<GameDTO>, ICollection<GameCardViewModel>>
                    (await _gameService.GetGamesAsync());
            }

            games = SortGames(sortOrder, games);
            GameCardListViewModel gameCardList = await CreateGameCardList(page, games);
            return View(gameCardList);
        }

        #region NonAction

        [NonAction]
        public async Task<GameCardListViewModel> CreateGameCardList(int page, ICollection<GameCardViewModel> games)
        {
            int pageSize = 1;
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
        public ICollection<GameCardViewModel> SortGames(GamesSortOrder sortOrder, ICollection<GameCardViewModel> games)
        {
            switch (sortOrder)
            {
                case GamesSortOrder.ByDateDescending:
                    return games.Reverse().ToList();
                case GamesSortOrder.ByRatingAscending:
                    return games.OrderBy(game => game.Rating).ToList();
                case GamesSortOrder.ByRatingDescending:
                    return games.OrderByDescending(game => game.Rating).ToList();
                default:
                    return games;
            }
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

        #endregion
    }
}