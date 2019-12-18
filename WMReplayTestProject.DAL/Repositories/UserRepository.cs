using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using WMReplayTestProject.DAL.Entities;
using WMReplayTestProject.DAL.Interfaces;

namespace WMReplayTestProject.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(AspNetUserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task AddUserAsync(User modelUser, string password)
        {
            try
            {
                var user = new User
                {
                    Email = modelUser.Email,
                    UserName = modelUser.Email
                };
                var result = await _userManager.CreateAsync(user, password);
            }
            catch
            {
                new ArgumentException("Регистрация нового поьзователя не прошла");
            }
            
        }

        public async Task<User> FindUserByIdAsync(int id)
        {
            try
            {
                var result = await _userManager.FindByIdAsync(id.ToString());
                return result;
            }
            catch
            {
                var result = await _userManager.FindByIdAsync(id.ToString());
                if (result == null)               
                    new ArgumentNullException("Ползователь не найден");
                return null;
            }
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            try
            {
                var result = await _userManager.FindByEmailAsync(email);
                return result;
            }
            catch
            {
                var result = await _userManager.FindByIdAsync(email);
                if (result == null)
                    new ArgumentNullException("Ползователь не найден");                    
                
                return null;
            }
        }

    }
}
