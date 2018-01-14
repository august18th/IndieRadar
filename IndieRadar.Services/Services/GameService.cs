using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces;

namespace IndieRadar.Services.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GameDTO>> GetGamesAsync()
        {
            var games = await _gameRepository.GetItemsAsync();
            if (games == null)
            {
                throw new NullReferenceException("Games does not exist");
            }

            return _mapper.Map<ICollection<Game>, ICollection<GameDTO>>(games);
        }

        public async Task<ICollection<GameDTO>> GetGamesByGenreAsync(string gameGenre)
        {
            if (gameGenre == null)
            {
                throw new ArgumentNullException(nameof(gameGenre));
            }

            var gamesOfTheGenre = await _gameRepository.FindAllAsync(g =>
                g.GameGenres.Any(c => c.Genre.GenreName == gameGenre));
            if (gamesOfTheGenre == null)
            {
                throw new NullReferenceException("Games with this genre does not exist");
            }
            return _mapper.Map<ICollection<Game>, ICollection<GameDTO>>(gamesOfTheGenre);
        }

        public Task<ICollection<GameDTO>> GetFilterGamesByRatingAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<GameDTO>> GetFilterGamesByRatingAndGenreAsync(string gameGenre)
        {
            throw new System.NotImplementedException();
        }

        public Task<GameDTO> GetGameByIdAsync(int gameId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateGame(GameDTO goal)
        {
            throw new System.NotImplementedException();
        }

        public void EditGame(GameDTO goalToEdit)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteGame(int gameId)
        {
            throw new System.NotImplementedException();
        }
    }
}