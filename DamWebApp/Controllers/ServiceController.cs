using DamWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DamWebApp.Filtters;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace DamWebApp.Controllers
{
    //[HandelError]
    //[Authorize]
    public class ServiceController : Controller
    {
        //10 endpoint "authorize"
        //1 allow gust
        private readonly ITestService service;

        public ServiceController(ITestService service)
        {
           
            this.service = service;
        }
      
        
        
        public IActionResult Welcome()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                //authorize welcome username
                Claim IdClaim= User.Claims.FirstOrDefault(c => c.Type ==ClaimTypes.NameIdentifier);//nameidentitifer
                string id = IdClaim.Value;
                Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Address");

                return Content($"Welcome Ya {User.Identity.Name}");
            }
            else
            {
                //anonumus  welcome Gust
                return Content("Welomce Gust");
            }
        }
        
        
        
        
        
        
        
        
        
        
        //redidrect login
        //Service/Index one Request (more than one inject)
        public IActionResult Index()
        {
            //send service id View 
            ViewData["Id"] = service.Id;
            return View();
        }

        //[HandelError]
        public IActionResult Method1()
        {
            
                throw new Exception("Exception throw ");
            
        }

        //[HandelError]
        [AllowAnonymous]//default filter
        public IActionResult Method2()
        {

            throw new Exception("Exception throw ");

        }
    }
}
