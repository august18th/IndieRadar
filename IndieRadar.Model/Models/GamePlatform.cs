using System;

namespace IndieRadar.Model.Models
{
    public class GamePlatform
    {
        public Game Game { get; set; }
        public Int32 GameId { get; set; }

        public Platform Platform { get; set; }
        public Int32 PlatformId { get; set; }
    }
}