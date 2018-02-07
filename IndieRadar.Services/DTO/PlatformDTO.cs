using System;
using System.Collections.Generic;
using IndieRadar.Model.Models;

namespace IndieRadar.Services.DTO
{
    public class PlatformDTO
    {
        public String Name { get; set; }
        public IList<GamePlatformDTO> GamePlatforms { get; set; }
    }
}