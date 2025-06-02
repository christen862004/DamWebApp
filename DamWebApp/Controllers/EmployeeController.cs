using DamWebApp.Models;
using DamWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult Index()
        {
            List<Employee> EmpList= context.Employees.ToList();
            return View("Index",EmpList);
        }
        #region New
        public IActionResult New()//oprn view
        {
            
            ViewBag.DeptList = context.Departments.ToList();//convert to IEnumerable<selectListITem>
            
            return View("New");
        }
        
        
        [HttpPost]//handel submit event 
        //handel only internal req not handel external req
        [ValidateAntiForgeryToken]//request.form["_reqquestVerificationToke"]
        public IActionResult SaveNew(Employee empFromReq) {
            if(empFromReq.Name!= null) {
                context.Employees.Add(empFromReq);
                context.SaveChanges();
                return RedirectToAction("Index","Employee");
            }
            ViewBag.DeptList = context.Departments.ToList();
            return View("New", empFromReq);
        }
        #endregion

        #region Edit
        ///Employee/Edit/@item.Id"
        public IActionResult Edit(int id)//open form 100% MEthod Get
        {
            //Collect dta
            Employee empFromDB= context.Employees.FirstOrDefault(e=>e.Id == id);
            List<Department> DeptList1=context.Departments.ToList();
            //ddecalare vM
            EmployeeWithDEptListViewModel empVM = new();
            //Mapping
            empVM.Id = empFromDB.Id;
            empVM.Name = empFromDB.Name;
            empVM.Email = empFromDB.Email;
            empVM.ImageURL = empFromDB.ImageURL;
            empVM.Salary = empFromDB.Salary;
            empVM.DepartmentId = empFromDB.DepartmentId;
            empVM.DeptList = DeptList1;
            //return VM
            return View("Edit",empVM);//Model=EmployeeWithDEptListViewModel
        }
        /*Post : /Employee/SaveEdit/1
    form {Name,Salary,ImageURL,Email,DepartmentID
    }
*/
        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDEptListViewModel EmpFromReq)
        //public IActionResult SaveEdit(Employee EmpFromReq)
        //public IActionResult SaveEdit(int id,string name,string email,...)
        {
            
            if(EmpFromReq.Name!=null && EmpFromReq.Salary > 7000)
            {
                //get old ref
                Employee EmpFromDb= context.Employees.FirstOrDefault(e=>e.Id==EmpFromReq.Id);
                //Change Modify based on comming data from reqq
                EmpFromDb.Name= EmpFromReq.Name;
                EmpFromDb.Email= EmpFromReq.Email;
                EmpFromDb.Salary= EmpFromReq.Salary;
                EmpFromDb.DepartmentId= EmpFromReq.DepartmentId;
                EmpFromDb.ImageURL= EmpFromReq.ImageURL;
                //Save chage
                context.SaveChanges();
                //return index
                return RedirectToAction("Index", "Employee");
            }
           
            EmpFromReq.DeptList = context.Departments.ToList();//refill
            return View("Edit", EmpFromReq);
        }


        #endregion


        #region DEtails
        public IActionResult Details(int id,string name)
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
