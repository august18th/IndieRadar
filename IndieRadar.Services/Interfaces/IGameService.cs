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
        Task<ICollection<GameDTO>> GetFilterGamesByRatingAsync();
        Task<ICollection<GameDTO>> GetFilterGamesByRatingAndGenreAsync(String gameGenre);
        Task<GameDTO> GetGameByIdAsync(Int32 gameId);
        void CreateGame(GameDTO goal);
        void EditGame(GameDTO goalToEdit);
        void DeleteGame(int gameId);
    }
}