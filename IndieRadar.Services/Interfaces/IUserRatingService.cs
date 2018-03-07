using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IndieRadar.Services.DTO;

namespace IndieRadar.Services.Interfaces
{
    public interface IUserRatingService
    {
        Task<ICollection<UserRatingDTO>> GetUserRatingsByUserAsync(String userId);
        Task<ICollection<UserRatingDTO>> GetUserRatingsByGameAsync(Int32 gameId);
        Task<UserRatingDTO> CreateUserRatingAsync(UserRatingDTO userRating);
        Task<UserRatingDTO> EditUserRatingAsync(UserRatingDTO userRating);
    }
}