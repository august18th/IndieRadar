using System;
using System.Collections.Generic;
using IndieRadar.Model.Models;

namespace IndieRadar.Services.DTO
{
    public class GenreDTO
    {
        public String GenreName { get; set; }
        public IList<GameGenre> GameGenres { get; set; }
    }
}