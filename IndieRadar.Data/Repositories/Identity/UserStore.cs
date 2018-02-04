using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using IndieRadar.Data.Infrastructure.Context;
using IndieRadar.Data.Interfaces.Repositories;
using IndieRadar.Data.Repositories.Base;
using IndieRadar.Model.Models;
using Microsoft.AspNet.Identity;

namespace IndieRadar.Data.Repositories.Identity
{
    public class UserStore : GenericRepository<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>, IUserLockoutStore<ApplicationUser, String>,
        IUserTwoFactorStore<ApplicationUser, String>, IUserRoleStore<ApplicationUser, String>,
        IRoleStore<Role, String>
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;

        public UserStore(IDbContext dbContext, IUserRoleRepository userRoleRepository, IRoleRepository roleRepository) : base(dbContext)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
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

        public async Task AddToRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Invalid role name");

            var role = await ((IRoleStore<Role, String>)this).FindByNameAsync(roleName);

            if (role == null)
                throw new InvalidOperationException("Role with this name doesn't exist");


            await _userRoleRepository.AddAsync(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            });
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Invalid role name");

            var role = await ((IRoleStore<Role, String>)this).FindByNameAsync(roleName);

            if (role == null)
                throw new InvalidOperationException("User is not in this role");

            var userRole = (await _userRoleRepository
                .GetItemsAsync(urs => urs.Where(ur => ur.UserId == user.Id && ur.RoleId == role.Id)))
                .FirstOrDefault();

            if (userRole == null)
                throw new InvalidOperationException($"User {user.UserName} is not in {roleName} role");

            await _userRoleRepository.RemoveAsync(userRole);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var userRoles =
                await _userRoleRepository.GetItemsAsync(
                    urs => urs.Include(ur => ur.Role).Where(ur => ur.UserId == user.Id));

            return await Task.FromResult(userRoles.Select(r => r.Role.Name).Distinct().ToList());
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Invalid role name");

            var role = await ((IRoleStore<Role, String>)this).FindByNameAsync(roleName);

            if (role == null)
                throw new InvalidOperationException("Role with this name doesn't exist");

            var userRoles =
                await _userRoleRepository.GetItemsAsync(
                    urs => urs.Where(ur => ur.UserId == user.Id && ur.RoleId == role.Id));

            return userRoles.FirstOrDefault() != null;
        }

        public async Task CreateAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            await _roleRepository.AddAsync(role);
        }

        public async Task UpdateAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            await _roleRepository.RemoveAsync(role);
        }

        async Task<Role> IRoleStore<Role, String>.FindByIdAsync(string roleId)
        {
            return await _roleRepository.FindFirstAsync(r => r.Id == roleId);
        }

        async Task<Role> IRoleStore<Role, String>.FindByNameAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ArgumentException("Invalid role name");

            return await _roleRepository.FindFirstAsync(r => r.Name.ToUpper() == roleName.ToUpper());
        }
    }
}