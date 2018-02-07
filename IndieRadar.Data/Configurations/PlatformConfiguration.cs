using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class PlatformConfiguration : EntityTypeConfiguration<Platform>
    {
        public PlatformConfiguration()
        {
            HasKey(c => c.Name);
        }
    }
}