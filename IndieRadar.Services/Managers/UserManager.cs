using System;
using System.Threading.Tasks;
using AutoMapper;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using IndieRadar.Services.Interfaces.Managers;
using Microsoft.AspNet.Identity;

namespace IndieRadar.Services.Managers
{
    public class UserManager : UserManager<ApplicationUser, String>, IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserStore<ApplicationUser, String> _userStore;

        public UserManager(IMapper mapper, IUserStore<ApplicationUser, String> store) : base(store)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userStore = store;
        }

        public async Task<IdentityResult> CreateAsync(UserDTO user, String password)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            ApplicationUser applicationUser = _mapper.Map<UserDTO, ApplicationUser>(user);
            return await base.CreateAsync(applicationUser, password);
        }

        public async Task<Boolean> IsExistUserNameAsync(String userName)
        {
            var user = await _userStore.FindByNameAsync(userName);
            return user != null;
        }
    }
}