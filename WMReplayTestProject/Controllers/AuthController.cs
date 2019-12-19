using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WMReplayTestProject.BLL.DTO;
using WMReplayTestProject.BLL.Interfaces;
using WMReplayTestProject.WEB.Models;

namespace WMReplayTestProject.WEB.Controllers
{
    public class AuthController : Controller
    {
        readonly private IUserService _userService;
        readonly private IAuthService _authService;
        readonly private IMapper _mapper;

        public AuthController(IUserService userService, IAuthService authService, IMapper mapper)
        {
            _userService = userService;
            _authService = authService;
            _mapper = mapper;
        }

     
        [HttpGet]
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
               return RedirectToAction("Index","Admin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.PasswordSignInAsync(model.Email, model.Password, true, false);
             
                if (result.Succeeded)
                {              
                        return RedirectToAction("Index", "Admin");
                
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            };
            var userDTO = _mapper.Map<RegisterViewModel, UserDTO>(model);

            var addedUser = await _userService.AddUserAsync(userDTO);
            if (addedUser.Succeeded)
            {
                await _authService.SignInAsync(userDTO);
                return RedirectToAction("Index", "Article");
            }
            else
            {
                foreach (var error in addedUser.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();
            return RedirectToAction("Index", "Article");
        }

    }
}
