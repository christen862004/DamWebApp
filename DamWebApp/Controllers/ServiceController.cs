using DamWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DamWebApp.Filtters;
namespace DamWebApp.Controllers
{
    //[HandelError]
    public class ServiceController : Controller
    {
        private readonly ITestService service;

        public ServiceController(ITestService service)
        {
           
            this.service = service;
        }
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
      //  [HandelError]
        public IActionResult Method2()
        {

            throw new Exception("Exception throw ");

        }
    }
}
