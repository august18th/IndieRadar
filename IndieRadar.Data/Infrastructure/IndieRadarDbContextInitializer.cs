using System.Collections.Generic;
using System.Data.Entity;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Infrastructure
{
    public class IndieRadarDbContextInitializer :
        DropCreateDatabaseIfModelChanges<IndieRadarDbContext>
    {
        protected override void Seed(IndieRadarDbContext context)
        {
            var initialGenres = new List<Genre>
            {
                new Genre {GenreName = "Arcade"},
                new Genre {GenreName = "Strategy"},
                new Genre {GenreName = "Adventure"},
                new Genre {GenreName = "RPG"},
                new Genre {GenreName = "Simulation"},
                new Genre {GenreName = "Sandbox"}
            };
            initialGenres.ForEach(m => context.Genres.Add(m));

            var initialPlatforms = new List<Platform>
            {
                new Platform {Name = "PC"},
                new Platform {Name = "PS4"},
                new Platform {Name = "Xbox One"},
                new Platform {Name = "Phone"}
            };
            initialPlatforms.ForEach(m => context.Platforms.Add(m));
            context.SaveChanges();
        }
    }
}