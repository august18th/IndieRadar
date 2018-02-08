using System;

namespace IndieRadar.Services.DTO
{
    public class GameGenreDTO
    {
        public GameDTO Game { get; set; }
        public Int32 GameId { get; set; }

        public GenreDTO Genre { get; set; }
        public String GenreName { get; set; }
    }
}