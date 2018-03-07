using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Repositories
{
    public class UserRatingRepository : GenericRepository<UserRating>, IUserRatingRepository
    {
        public UserRatingRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}