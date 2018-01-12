using System.Data.Entity;

namespace IndieRadar.Data.Infrastructure.Context
{
    public class IndieRadarDbContext : DbContext, IDbContext
    {
        private const string DbName = "IndieRadarDb";

        public IndieRadarDbContext() : base(DbName)
        {
        }
    }
}