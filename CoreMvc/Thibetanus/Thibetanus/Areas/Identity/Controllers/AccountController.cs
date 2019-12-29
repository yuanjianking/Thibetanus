using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Thibetanus.Areas.Identity.Models;
using Thibetanus.Controllers;
using Thibetanus.Models;

namespace Thibetanus.Areas.Identity.Controllers
{    
    [Area("Identity")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;//创建用户的
        private SignInManager<ApplicationUser> _signInManager;//用来登录的

        //依赖注入
        public AccountController(MyUserManager userManager, MySignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = "/home/index";
            return View();
        }

         [HttpPost]
         [AllowAnonymous]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
         {
             ViewData["ReturnUrl"] = returnUrl;
             if (ModelState.IsValid)
             {
                 // This doesn't count login failures towards account lockout
                 // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                 var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                 if (result.Succeeded)
                 {
                     return RedirectToLocal(returnUrl);
                 }
                 else
                 {
                     ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                     return View(model);
                 }
             }
             // If we got this far, something failed, redisplay form
             return View(model);
         }

         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Logout()
         {
             await _signInManager.SignOutAsync();
             return RedirectToAction(nameof(HomeController.Index), "Home");
         }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {//如果是本地
                return Redirect(@"/home/index");
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }        
    }
}
