using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}