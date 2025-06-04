using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class StateController : Controller
    {
        //State/Setsession
        public IActionResult SetSession(string name,int age)
        {
            //logic
            //obj ==> Json
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content($"Session Save");
        }
        //State/GetSession new Object
        public IActionResult GetSession()
        {
            //logic
            string n = HttpContext.Session.GetString("Name");
            int? a   = HttpContext.Session.GetInt32("Age");
            return Content($"{n}\t{a}");
        }


        public IActionResult SetCookie(string name,int age)
        {
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", name);
            //Presistent Cookie
            CookieOptions options= new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);
            
            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);
            return Content("Cookie SAved");
        }

        public IActionResult GetCookie() {
           //logic
            string n= HttpContext.Request.Cookies["Name"]; 
            string a= HttpContext.Request.Cookies["Age"]; 
            return Content($"Cookie {n}\n {a}");

        }
    }
}
