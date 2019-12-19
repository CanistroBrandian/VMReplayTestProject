using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;

namespace WMReplayTestProject.BLL.Interfaces
{
    public interface IAuthService
    {
        Task SignInAsync(UserDTO item, bool flag = false);
        Task SignOutAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<SignInResult> PasswordSignInAsync(string email, string pass, bool isPersistent, bool lockoutOnFailure);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(UserDTO userDTO);
    }
}
