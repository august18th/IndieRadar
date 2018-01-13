using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserConfiguration()
        {
            Property(c => c.Email).IsRequired().HasMaxLength(150);
            Property(c => c.FirstName).IsRequired().HasMaxLength(20);
            Property(c => c.LastName).HasMaxLength(100);
        }
    }
}