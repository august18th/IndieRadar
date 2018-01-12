using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Repositories
{
    public class CommentUserRepository :
        GenericRepository<CommentUser>, ICommentUserRepository
    {
        public CommentUserRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}