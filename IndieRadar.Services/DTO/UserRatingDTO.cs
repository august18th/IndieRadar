using System;
using IndieRadar.Model.Models;

namespace IndieRadar.Services.DTO
{
    public class UserRatingDTO
    {
        public String UserId { get; set; }
        public UserDTO User { get; set; }

        public Int32 GameId { get; set; }
        public GameDTO Game { get; set; }

        public Int32 Rating { get; set; }
    }
}