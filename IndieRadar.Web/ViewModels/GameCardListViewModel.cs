using System.Collections.Generic;
using IndieRadar.Web.Models;

namespace IndieRadar.Web.ViewModels
{
    public class GameCardListViewModel
    {
        public IList<GameCardViewModel> GameCards { get; set; }
        public PageInfo PageInfo { get; set; }
        public GameCriterias FilterCriterias { get; set; }
    }
}