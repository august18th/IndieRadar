using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }


        // GET: Games
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)
        {
            int pageSize = 10;
            var games = await _gameService.GetGamesAsync();
            var gameCards = _mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameCardViewModel>>
                (games.Skip((page - 1) * pageSize).Take(pageSize));

            PageInfo pageInfo = new PageInfo
            {
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = games.Count
            };
            GameCardListViewModel gameCardList = new GameCardListViewModel
            {
                PageInfo = pageInfo,
                GameCards = gameCards.ToList()
            };
            return View(gameCardList);
        }
    }
}