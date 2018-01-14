using System;

namespace IndieRadar.Model.Models
{
    public class GameGenre
    {
        public Game Game { get; set; }
        public Int32 GameId { get; set; }

        public Genre Genre { get; set; }
        public String GenreName { get; set; }
    }
}