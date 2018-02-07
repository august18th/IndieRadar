using System;
using System.Collections.Generic;

namespace IndieRadar.Model.Models
{
    public class Platform
    {
        public String Name { get; set; }
        public IList<GamePlatform> GamePlatforms { get; set; }
    }
}