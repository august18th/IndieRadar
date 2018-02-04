using System;
using System.Collections.Generic;
using IndieRadar.Model.Models;

namespace IndieRadar.Web.ViewModels
{
    public class PlatformViewModel
    {
        public String Name { get; set; }
        public IList<GamePlatform> GamePlatforms { get; set; }
    }
}