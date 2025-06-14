using DamWebApp.Models;
using DamWebApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;

namespace DamWebApp.Controllers
{
    public class AccountController : Controller
    {
        UserManager <AppLicationUser> userManager;
        SignInManager<AppLicationUser> signInManager;
        public AccountController
            (UserManager<AppLicationUser> userManager,SignInManager<AppLicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register    
        public IActionResult Register()
        {
            return View("Register");
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                //create account
                AppLicationUser user = new AppLicationUser() { 
                    UserName       = UserVM.UserName,
                    Address        = UserVM.Address,
                    PasswordHash   = UserVM.Password
                };   
                IdentityResult result=await userManager.CreateAsync(user,UserVM.Password);//success  | Fail
                if (result.Succeeded)
                {
                    //assign user to role admin
                    await userManager.AddToRoleAsync(user, "Admin");

                    await signInManager.SignInAsync(user, false);
                    //create cookie with specific claim (id ,name ,[email] ,[role])
                    return RedirectToAction("Index", "Department");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register",UserVM);
        }

        #endregion

        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                //check
                AppLicationUser user= await userManager.FindByNameAsync(loginUser.UserName);
                if (user != null)
                {
                    bool found=await userManager.CheckPasswordAsync(user, loginUser.Password);
                    if (found)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Address", user.Address));
                        await signInManager.SignInWithClaimsAsync(user, loginUser.RememberMe, Claims);

                        //await signInManager.SignInAsync(user, loginUser.RememberMe);//id, name,role ,email
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalidd Account");
            }
            return View("Login", loginUser);
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion
    }
}
