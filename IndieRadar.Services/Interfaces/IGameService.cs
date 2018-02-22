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
        Task<ICollection<GameDTO>> GetGamesByPlatformAsync(String gamePlatform);
        Task<GameDTO> GetGameByIdAsync(Int32? gameId);
        Task<GameDTO> CreateGameAsync(GameDTO game);
        Task<GameDTO> EditGameAsync(GameDTO gameToEdit);
        Task<Boolean> DeleteGameAsync(int gameId);
    }
}