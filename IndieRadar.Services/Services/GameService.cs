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
                g.GameGenres.Any(c => c.GenreName == gameGenre));
            if (gamesOfTheGenre == null)
            {
                throw new NullReferenceException("Games with this genre does not exist");
            }
            return _mapper.Map<ICollection<Game>, ICollection<GameDTO>>(gamesOfTheGenre);
        }

        public async Task<ICollection<GameDTO>> GetSortedGamesByRatingAsync()
        {
            var games = await _gameRepository.GetItemsAsync();
            if (games == null)
            {
                throw new NullReferenceException("Games does not exist");
            }

            return _mapper.Map<ICollection<Game>, ICollection<GameDTO>>(games.OrderBy(g => g.Rating).ToList());
        }

        public async Task<ICollection<GameDTO>> GetSortedGamesByRatingAndByGenreAsync(string gameGenre)
        {
            if (gameGenre == null)
            {
                throw new ArgumentNullException(nameof(gameGenre));
            }

            var gamesOfTheGenre = await _gameRepository.FindAllAsync(g =>
                g.GameGenres.Any(c => c.GenreName == gameGenre));
            if (gamesOfTheGenre == null)
            {
                throw new NullReferenceException("Games with this genre does not exist");
            }
            return _mapper.Map<ICollection<Game>, ICollection<GameDTO>>(gamesOfTheGenre.OrderBy(g => g.Rating).ToList());
        }

        public async Task<GameDTO> GetGameByIdAsync(int? gameId)
        {
            if (gameId == null)
            {
                throw new ArgumentNullException(nameof(gameId));
            }
            var game = await _gameRepository.FindFirstAsync(g => g.Id == gameId);
            if (game == null)
            {
                throw new NullReferenceException("Game with this id does not exist");
            }
            return _mapper.Map<Game, GameDTO>(game);
        }

        public async Task<GameDTO> CreateGameAsync(GameDTO game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            var createdGame = await _gameRepository.AddAsync(_mapper.Map<GameDTO, Game>(game));
            if (createdGame == null)
            {
                throw new NullReferenceException("Game was not added");
            }
            return _mapper.Map<Game, GameDTO>(createdGame);
        }

        public async Task<GameDTO> EditGameAsync(GameDTO gameToEdit)
        {
            if (gameToEdit == null)
            {
                throw new ArgumentNullException(nameof(gameToEdit));
            }

            var editedGame = await _gameRepository.UpdateAsync(_mapper.Map<GameDTO, Game>(gameToEdit));
            if (editedGame == null)
            {
                throw new NullReferenceException("Game was not edited");
            }
            return _mapper.Map<Game, GameDTO>(editedGame);
        }

        public async Task<Boolean> DeleteGameAsync(int gameId)
        {
            try
            {
                var game = await GetGameByIdAsync(gameId);
                return await _gameRepository.RemoveAsync(_mapper.Map<GameDTO, Game>(game));
            }
            catch (NullReferenceException exception)
            {
                throw new NullReferenceException(exception.Message);
            }
        }
    }
}