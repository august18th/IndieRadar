using System;
using System.Collections.Generic;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class Platform : BaseEntity
    {
        public String Name { get; set; }
        public IList<GamePlatform> GamePlatforms { get; set; }
    }
}