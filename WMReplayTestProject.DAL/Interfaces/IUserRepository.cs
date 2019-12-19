using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserAsync(User modelUser, string password);
        Task<User> FindUserByIdAsync(int id);
        Task<User> FindUserByEmailAsync(string email);
    }
}
