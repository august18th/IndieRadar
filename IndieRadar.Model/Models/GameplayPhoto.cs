using System;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class GameplayPhoto : BaseEntity
    {
        public Byte[] Photo { get; set; }

        public Int32 GameId { get; set; }
        public Game Game { get; set; }
    }
}