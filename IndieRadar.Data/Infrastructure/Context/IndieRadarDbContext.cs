using System;
using System.Data.Entity;
using IndieRadar.Data.Configurations;
using IndieRadar.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IndieRadar.Data.Infrastructure.Context
{
    public class IndieRadarDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        private const string DbName = "IndieRadarDb";

        public IndieRadarDbContext() : base(DbName)
        {
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<GamePlatform> GamePlatforms { get; set; }
        public IDbSet<Platform> Platforms { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<GameGenre> GameGenres { get; set; }
        public IDbSet<GameplayPhoto> GameplayPhotos { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<CommentUser> CommentUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new GamePlatformConfiguration());
            modelBuilder.Configurations.Add(new GameGenreConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
        }
    }
}