using System;
using System.Collections.Generic;
using IndieRadar.Model.Models;

namespace IndieRadar.Web.ViewModels
{
    public class GenreViewModel
    {
        public String GenreName { get; set; }
        public IList<GameGenre> GameGenres { get; set; }
    }
}