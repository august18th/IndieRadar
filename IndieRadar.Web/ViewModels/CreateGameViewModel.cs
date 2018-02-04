using System.Collections.Generic;

namespace IndieRadar.Web.ViewModels
{
    public class CreateGameViewModel
    {
        public IList<GenreViewModel> Genres { get; set; }

        public IList<PlatformViewModel> Platforms { get; set; }
    }
}