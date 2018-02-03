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
        IUserPasswordStore<ApplicationUser>, IUserLockoutStore<ApplicationUser, String>,
        IUserTwoFactorStore<ApplicationUser, String>
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

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.LockoutEndDateUtc.HasValue
                ? new DateTimeOffset(DateTime.SpecifyKind(user.LockoutEndDateUtc.Value, DateTimeKind.Utc))
                : new DateTimeOffset());
        }

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.LockoutEndDateUtc = lockoutEnd == DateTimeOffset.MinValue
                ? new DateTime?()
                : lockoutEnd.UtcDateTime;

            return Task.FromResult(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.AccessFailedCount++;
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.AccessFailedCount = 0;
            return Task.FromResult(0);
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            user.LockoutEnabled = enabled;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return await Task.FromResult(false);
        }
    }
}