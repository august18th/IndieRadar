using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace IndieRadar.Web.Infrastructure
{
    public interface ISignInService
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);
    }
}