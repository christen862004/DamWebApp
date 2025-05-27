using DamWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBl = new StudentBL();
        //Student/All
        public IActionResult All() {
            //1) Model Get data
            List<Student> stdList= studentBl.GetAll();
            //2)send to view 
            return View("ShowAll",stdList);//send List<student
            //View NAme: ShowAll //Views/Studnt/ShowAll.cs
        }
    }
}
