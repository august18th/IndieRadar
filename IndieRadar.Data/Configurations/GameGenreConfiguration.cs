using System.Data.Entity.ModelConfiguration;
using System.Runtime.CompilerServices;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class GameGenreConfiguration : EntityTypeConfiguration<GameGenre>
    {
        public GameGenreConfiguration()
        {
            HasKey(p => new { p.GameId, p.GenreId });
        }
    }
}