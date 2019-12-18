using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;

        public AuthService(IUserService userService, IMapper mapper, SignInManager<User> signInManager)
        {
            _userService = userService;
            _mapper = mapper;
            _signInManager = signInManager;
        }
        public bool IsSignedIn(ClaimsPrincipal principal)
        {
           return _signInManager.IsSignedIn(principal);
        }

        public async Task<SignInResult> PasswordSignInAsync(string email, string pass, bool isPersistent, bool lockoutOnFailure)
        {
            try
            {
                return await _signInManager.PasswordSignInAsync(email, pass, isPersistent, lockoutOnFailure);
            }
            catch
            {
                new Exception("Ошибка при аунтификации");
                return SignInResult.Failed;
            }
        }

        public async Task SignInAsync(UserDTO item, bool flag = false)
        {
            try
            {
                var user = _mapper.Map<UserDTO, User>(item);
                await _signInManager.SignInAsync(user, false);
            }
            catch
            {
                new Exception("Ошибка при авторизации");
            }
        }

        public async Task SignOutAsync()
        {
            try
            {
                  await _signInManager.SignOutAsync();
            }
            catch
            {
                new Exception("Ошибка при выходе из аккаунта");
            }
        }
    }
}
