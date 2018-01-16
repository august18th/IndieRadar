using System;
using System.Collections.Generic;
using IndieRadar.Model.Models;

namespace IndieRadar.Web.ViewModels
{
    public class GameCardViewModel
    {
        public String GameName { get; set; }
        public String DevelopmentPhase { get; set; }
        public String Description { get; set; }
        public Byte[] MainPhoto { get; set; }
        public Double? Rating { get; set; }
        public String Version { get; set; }

        public IList<GameGenre> GameGenres { get; set; }
    }
}