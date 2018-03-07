using System;

namespace IndieRadar.Model.Models
{
    public class UserRating
    {
        public String UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Int32 GameId { get; set; }
        public Game Game { get; set; }

        public Int32 Rating { get; set; }
    }
}
