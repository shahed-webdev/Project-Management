﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Repository;
using ProjectManagement.ViewModel;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(IUnitOfWork db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //GET: Login
        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Dashboard");

            return View();
        }


        //POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var type = _db.Registration.UserTypeByUserName(model.UserName);

                return type switch
                {
                    UserType.Admin => LocalRedirect(returnUrl ??= Url.Content("~/Dashboard/Index")),
                    _ => LocalRedirect(returnUrl ??= Url.Content("~/Account/Index"))
                };
            }

            if (result.RequiresTwoFactor) return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, model.RememberMe });

            if (result.IsLockedOut)
                return RedirectToPage("./Lockout");


            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View(model);
        }


        // GET: ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        //POST: logout
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null) return LocalRedirect(returnUrl);

            return RedirectToAction("Index", "Account");
        }
    }
}
