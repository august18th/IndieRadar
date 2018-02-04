using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Repositories.Identity
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}