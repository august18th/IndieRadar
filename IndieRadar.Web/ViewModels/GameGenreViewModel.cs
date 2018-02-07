using System;

namespace IndieRadar.Web.ViewModels
{
    public class GameGenreViewModel
    {
        public CreateGameViewModel Game { get; set; }
        public String GameId { get; set; }

        public GenreViewModel Genre { get; set; }
        public String GenreName { get; set; }

    }
}