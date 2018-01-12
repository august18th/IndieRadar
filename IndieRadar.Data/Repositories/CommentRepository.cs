using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;

namespace IndieRadar.Data.Repositories
{
    public class CommentRepository : GenericRepository<Comment> , ICommentRepository
    {
        public CommentRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}