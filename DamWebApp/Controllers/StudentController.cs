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

        //Student/Details/1
        //Student/Details?id=1
        public IActionResult Details(int id)
        {
            Student stdModel = studentBl.GetByID(id);
            return View("Details", stdModel);//View Ddetails ,Model ==Student
        }
    }
}
