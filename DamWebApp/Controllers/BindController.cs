using DamWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class BindController : Controller
    {
        //Bind/test
        [HttpGet]
        public IActionResult test()
        {
            return Content("test get");
        }
        //Bind/test?id=1&name=ahmed
        //Bindd/Test
        [HttpPost]
        public IActionResult test(int id ,string name)
        {
            return Content("test Oveloadd post");
        }


        /*
         <form action="/Bind/TestPrimitive/120" method="get">
            <input name="age">
            <input name="name">
            <input name="Color[0]">
            <input name="Color[1]">
            <input name="Color[2]">
            <input name="phone[ahmed]">
            
        </form>
         */
        //Bind/TestPrimitive?age=16&name=Ahmed&id=120
        //Bind/TestPrimitive/120?age=16&name=Ahmed&color=red&color=blue
        //http://localhost:62074/bind/TestPrimitive?color[1]=red&color[0]=blue
        public IActionResult TestPrimitive(int age ,string name,int id ,string[] color)
        {
            return Content("Ok");
        }


        //Bind/TestDic?name=Christen&phone[ahmed]=123&phone[mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> phone,string name)
        {
            return Content("ok");
        }


        //Object Complex Type
        //Bind/TestObj?id=1&Name=sdd&ManagerName=ahmed
        //http://localhost:62074/Bind/TestObj?id=1&Name=sdd&ManagerName=ahmed&Employees[0].id=1&Employees[0].name=sara
        public IActionResult TestObj(Department dept)//create obj
        //public IActionResult TestObj(int Id, string Name, string ManagerName, List<Employee> Employees)
        {
            return Content("ok");
        }
    }
}
