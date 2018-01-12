using System;

namespace IndieRadar.Model.Models
{
    public class GameplayPhoto
    {
        public Byte[] Photo { get; set; }

        public Int32 GameId { get; set; }
        public Game Game { get; set; }
    }
}