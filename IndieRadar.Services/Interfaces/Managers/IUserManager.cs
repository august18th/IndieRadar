using System;
using System.Threading.Tasks;
using IndieRadar.Model.Models;
using IndieRadar.Services.DTO;
using Microsoft.AspNet.Identity;

namespace IndieRadar.Services.Interfaces.Managers
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(UserDTO user, String password);
        Task<ApplicationUser> FindByNameAsync(String userName);
        Task<Boolean> IsExistUserNameAsync(String userName);
    }
}