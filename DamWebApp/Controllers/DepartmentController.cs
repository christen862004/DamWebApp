using DamWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new ITIContext();
        public DepartmentController()
        {
            
        }

        public IActionResult Index()
        {
            List<Department> DeptModel= context.Departments.ToList();
            return View("Index",DeptModel);//ViewName="Index" ,Model==> List<department>
        }

        public IActionResult New()
        {
            return View("New");//View=New ,Model =Null
        }
        ///Department/SaveNew?Name=val&ManagerName=value
        [HttpPost]
        public IActionResult SaveNew(Department DeptFromReq)//string name,string managerName)
        {
            #region done by Model Binder
            //Department dept = new Department();
            //dept.Name = name;
            //dept.ManagerName = managerName;
            #endregion
            //if (Request.Method == "POST")
            //{
            if (DeptFromReq.Name != null && DeptFromReq.ManagerName != null)
            {
                context.Departments.Add(DeptFromReq);
                context.SaveChanges();

                return RedirectToAction("Index", "Department");
            }
            
            return View("New", DeptFromReq);//View =NEw , Model= DEpartment
            //}
            //return NotFound();
        }
    }
}
