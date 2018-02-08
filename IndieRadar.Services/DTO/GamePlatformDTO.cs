using System;

namespace IndieRadar.Services.DTO
{
    public class GamePlatformDTO
    {
        public GameDTO Game { get; set; }
        public Int32 GameId { get; set; }

        public PlatformDTO Platform { get; set; }
        public String PlatformName { get; set; }
    }
}