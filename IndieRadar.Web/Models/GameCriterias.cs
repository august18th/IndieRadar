using System.Collections.Generic;
using IndieRadar.Web.ViewModels;

namespace IndieRadar.Web.Models
{
    public class GameCriterias
    {
        public IList<GenreViewModel> Genres { get; set; }

        public IList<PlatformViewModel> Platforms { get; set; }
    }
}