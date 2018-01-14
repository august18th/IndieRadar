using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IndieRadar.Services.DTO;

namespace IndieRadar.Services.Interfaces
{
    public interface IGameService
    {
        Task<ICollection<GameDTO>> GetGamesAsync();
        Task<ICollection<GameDTO>> GetGamesByGenreAsync(String gameGenre);
        Task<ICollection<GameDTO>> GetSortedGamesByRatingAsync();
        Task<ICollection<GameDTO>> GetSortedGamesByRatingAndByGenreAsync(String gameGenre);
        Task<GameDTO> GetGameByIdAsync(Int32? gameId);
        Task<GameDTO> CreateGameAsync(GameDTO game);
        Task<GameDTO> EditGameAsync(GameDTO gameToEdit);
        Task<Boolean> DeleteGameAsync(int gameId);
    }
}