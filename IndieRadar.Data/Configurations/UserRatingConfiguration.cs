using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class UserRatingConfiguration : EntityTypeConfiguration<UserRating>
    {
        public UserRatingConfiguration()
        {
            HasKey(r => new { r.GameId, r.UserId });
        }
    }
}