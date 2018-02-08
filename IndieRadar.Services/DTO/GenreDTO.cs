using System;
using System.Collections.Generic;

namespace IndieRadar.Services.DTO
{
    public class GenreDTO
    {
        public String Name { get; set; }
        public IList<GameGenreDTO> GameGenres { get; set; }
    }
}