using DamWebApp.Models;
using DamWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        #region DEtails
        public IActionResult Details(int id)
        {
            //-------------Send More than one infor
            string msg = "Hello";
            int Temp = 39;
            List<string> branches = new(){"Alex","Smart","New Capital","Sohag"};
            ViewData["Message"] = msg;
            ViewData["Temp"] = Temp;
            ViewData["Brch"] = branches;
            ViewData["Color"] = "red";
            ViewBag.age = 12;
            ViewBag.Color = "Blue";
            //new entry ,throw exception ,override

            //-------------------------------------
            Employee emp= context.Employees.FirstOrDefault(e=>e.Id==id);
            return View("Details",emp);//Model ==> Employee
        }

        public IActionResult DetailsVM(int id)
        {
            //collect ddata
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            string msg = "Hello";
            int Temp = 39;
            List<string> branches = new() { "Alex", "Smart", "New Capital", "Sohag" };

            //ddeclare Viewmodel
            EmployeeNameWithMsgColorBranchListViewModel empVM = new();

            //mapping get info collet set in ViewModel
            empVM.EmpId = empModel.Id;
            empVM.EmpName = empModel.Name;
            empVM.Message = msg;
            empVM.Temp = Temp;
            empVM.Branches = branches;
            empVM.Color = "red";

            //return viewMdoe to view
            return View("DetailsVM", empVM);
            //view : DetailsVM
            //Model : EmployeeNameWithMsgColorBranchListViewModel
        }
        #endregion

    }
}
