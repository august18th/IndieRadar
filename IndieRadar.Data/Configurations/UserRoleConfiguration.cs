using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            HasKey(p => new { p.RoleId, p.UserId });
        }
    }
}