using IndieRadar.Web.Models;

namespace IndieRadar.Web.ViewModels
{
    public class CreateGameViewModel
    {
        public GameViewModel Game { get; set; }

        public GameCriterias GameCriterias { get; set; }
    }
}