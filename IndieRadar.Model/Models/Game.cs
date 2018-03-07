using System;
using System.Collections.Generic;
using IndieRadar.Model.Models.Base;

namespace IndieRadar.Model.Models
{
    public class Game : BaseEntity
    {
        public String GameName { get; set; }
        public String DevelopmentPhase { get; set; }
        public String Developer { get; set; }
        public String Description { get; set; }
        public Byte[] MainPhoto { get; set; }
        public String Version { get; set; }

        public IList<UserRating> Ratings { get; set; }

        public IList<GameGenre> GameGenres { get; set; }

        public IList<GamePlatform> GamePlatforms { get; set; }

        public IList<GameplayPhoto> GameplayPhotos { get; set; }
    }
}