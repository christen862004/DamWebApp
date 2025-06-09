using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class RouteController : Controller
    {
       
        //Route/Method1?name=ahmed&age=10
        //r1?name=ahmed&age=10 ==>QueryString
        //r1/{age}/{name}
        //r1/12/ahmed
        //r1/22/Alaa
        //r1/25/basem
        //r1/{age}/{name}
        //r1/25
        //r1/25/basem
        //routevalue={controller=route ,action = Method1 ,age=basem ,anem=25
        public IActionResult Method1()//string name,int age)
        {
            return Content("Method1");
        }
        //Route/Method2
        //r2
        public IActionResult Method2()
        {
            return Content("Method2");
        }
        //Route/MEthod3 not found
        [Route("r3")]//this route the only one //using web api
        public IActionResult Method3()
        {
            return Content("Method3");

        }
    }
}
