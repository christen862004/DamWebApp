using DamWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DamWebApp.Controllers
{
    /// 1) name of calss sufiex with Controller "Home"    
    /// 2) class inhert from Controller class   "ControllerFactory"
    public class HomeController : Controller
    {
        //any funation consider action "URL"
        //1) Must Be Public "Create object"
        //2) Cant be Static
        //3) Cant be Overload only in one Case
        //URL : //Home/ShowMsg  "endpoint"
        public ContentResult  ShowMsg()
        {
            //logic
            //declare
            ContentResult result = new ContentResult();
            //set
            result.Content = "Hello FRom My first Action";
            //return
            return result;
        }

        public ViewResult ShowView()
        {
            //logic.........
            //declare
            ViewResult result=new ViewResult();
            //fill
            result.ViewName = "View1";
            //return 
            return result;
        }

        //home/showmix?ID=19&name=ahmed  [QueryString]
        //home/showmix/19?name=ahemd     [Route Value]
        public IActionResult ShowMix(int id,string name)
        {
            if (id % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                return Content("Message");
            }
        }
        ////Dry
        //[NonAction]
        //public ViewResult View(string viewNAme)
        //{
        //    ViewResult result = new ViewResult();
        //    //fill
        //    result.ViewName = viewNAme;
        //    //return 
        //    return result;
        //}



        //----------------------Action can return---------------
        /// <summary>
        /// 1) Content  ==> ContentResult
        /// 2) View     ==> ViewResult
        /// 3) Json     ==> JsonResult               Actionresult  ==>IActionREsult
        /// 4) Empty    ==> EmptyResult
        /// 5) NotFound ==> NotFoundReuslt
        /// .........
        /// </summary>







        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
