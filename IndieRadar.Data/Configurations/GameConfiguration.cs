using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            Property(f => f.GameName).HasMaxLength(50).IsRequired();
            Property(f => f.Description).HasMaxLength(200).IsRequired();
            Property(g => g.Developer).HasMaxLength(50).IsRequired();
        }
    }
}