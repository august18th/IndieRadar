using System;
using System.Linq;
using System.Threading.Tasks;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;
using Microsoft.AspNet.Identity;

namespace IndieRadar.Data.Repositories.Identity
{
    public class UserStore : GenericRepository<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>
    {
        public UserStore(IDbContext dbContext) : base(dbContext)
        {

        }

        public new async Task UpdateAsync(ApplicationUser item)
        {
            var user = DbSet.Find(item.Id);
            await base.UpdateAsync(user);
        }

        public async Task CreateAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await AddAsync(user);
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await RemoveAsync(user);
        }

        public void Dispose()
        {

        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await FindFirstAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Invalid user name");

            var user = (await GetItemsAsync(e =>
                e.Where(u => u.UserName.ToUpper() == userName.ToUpper()))).FirstOrDefault();
            return user;
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.PasswordHash));
        }
    }
}