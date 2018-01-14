using System.Data.Entity.ModelConfiguration;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Configurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            HasKey(g => g.GenreName);
        }
    }
}