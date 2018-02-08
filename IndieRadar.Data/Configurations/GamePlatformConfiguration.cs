using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class GamePlatformConfiguration : EntityTypeConfiguration<GamePlatform>
    {
        public GamePlatformConfiguration()
        {
            HasKey(p => new { p.GameId, p.PlatformName });
        }
    }
}