using Blog.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            if (result.Succeeded)
            {
                //Login Successful
                return RedirectToAction("Index", "AdminPanel");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
