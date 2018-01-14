using System;
using System.Collections.Generic;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class Genre
    {
        public String GenreName { get; set; }
        public IList<GameGenre> GameGenres { get; set; }
    }
}