using DamWebApp.Models;
using DamWebApp.Repository;
using DamWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIContext context = new ITIContext();
        //DIP + IOC
        IEmployeeRepository EmpRepository=null;
        IDepartmentRepository DeptRepository;
        public EmployeeController(IEmployeeRepository empRepo, IDepartmentRepository depRepo)
        {
            this.EmpRepository=empRepo;
            this.DeptRepository=depRepo;
            //EmpRepository = new EmployeeRepository();//dont create
            //DeptRepository= new DepartmentRepository();
        }

        public IActionResult Index()
        {
            List<Employee> EmpList= EmpRepository.GetAll();
            return View("Index",EmpList);
        }

        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 6000)
                return Json(true);
            else 
                return Json(false);
        }
        #region New
        public IActionResult New()//oprn view
        {
            //declare ViewModel (fill Lists)
            ViewBag.DeptList = DeptRepository.GetAll();//convert to IEnumerable<selectListITem>
            
            return View("New");
        }
        //Employee/SaveNEw 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee empFromReq) {
            if (ModelState.IsValid==true)//server side Validation
            {
                try
                {
                    //mapping Employee emp=new Employee()
                    EmpRepository.Add(empFromReq);
                    EmpRepository.Save();
                    return RedirectToAction("Index", "Employee");//end of Function
                }catch(Exception ex)
                {
                    //send exception text Ddiv
                    //ModelState.AddModelError("DepartmentId", "Please Select Department");
                    ModelState.AddModelError("ayKey",ex.InnerException.Message);
                }
            }

            ViewBag.DeptList = DeptRepository.GetAll();
            //empFromReq.DeptList= context.Departments.ToList();
            return View("New", empFromReq);

        }
        #endregion

        #region Edit
        ///Employee/Edit/109"
        public IActionResult Edit(int id)//open form 100% MEthod Get
        {
            //Collect dta
            Employee empFromDB = EmpRepository.GetById(id);
            if (empFromDB != null)
            {
                List<Department> DeptList1 = DeptRepository.GetAll();
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
                return View("Edit", empVM);//Model=EmployeeWithDEptListViewModel
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDEptListViewModel EmpFromReq)
        {
            
            if(EmpFromReq.Name!=null && EmpFromReq.Salary > 8000)
            {
                //get old ref
                Employee EmpFromDb =
                    new Employee();
                //Change Modify based on comming data from reqq
                EmpFromDb.Id= EmpFromReq.Id;
                EmpFromDb.Name= EmpFromReq.Name;
                EmpFromDb.Email= EmpFromReq.Email;
                EmpFromDb.Salary= EmpFromReq.Salary;
                EmpFromDb.DepartmentId= EmpFromReq.DepartmentId;
                EmpFromDb.ImageURL= EmpFromReq.ImageURL;
                EmpRepository.Update(EmpFromDb);
                //Save chage
                EmpRepository.Save();
                //return index
                return RedirectToAction("Index", "Employee");
            }
           
            EmpFromReq.DeptList = DeptRepository.GetAll();//refill
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
            Employee emp= EmpRepository.GetById(id);
            return View("Details",emp);//Model ==> Employee
        }

        public IActionResult DetailsVM(int id)
        {

            //collect ddata
            Employee empModel = EmpRepository.GetById(id);
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
