using DamWebApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DamWebApp.Controllers
{
    [Authorize(Roles ="Admin")]//cookie Roles
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleVM)
        {
            if(ModelState.IsValid)
            {
                //create role
                IdentityRole role = new IdentityRole()
                {
                    Name = roleVM.RoleName
                };
                IdentityResult result= await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return View("Create");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }
            }
            return View("Create",roleVM);
        }
    }
}
