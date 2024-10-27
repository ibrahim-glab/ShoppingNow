using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingNow.core.Entities;
using ShoppingNow.Helper;
using ShoppingNow.Models;
using ShoppingNow.Service.Interfaces;

namespace ShoppingNow.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager; 
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;


        public AccountController(SignInManager<ApplicationUser> signInManager,  IUserService userService, ILogger<HomeController> logger)
        {
            
            _signInManager = signInManager;
            _userService = userService;
            _logger = logger;
        }

        public async  Task<IActionResult> Login()
        {
            var userLoginViewModel = new LoginViewModel();
            return View(userLoginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
                return View(loginViewModel);
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,
                    loginViewModel.RememberMe, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("" , "Invalid Email or Password");
                    return View(loginViewModel);
                }
                return RedirectToAction("index" , "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Home");
            }
          
            
        }
        // add register Methods 

        public async Task<IActionResult> Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Email,Password,ConfirmPassword")] RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);
            try
            {
                var user = registerViewModel.ToUserDto();
                var result = await _userService.AddUser(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("" , error.Description);
                    }
                    return View(registerViewModel);
                }

                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
