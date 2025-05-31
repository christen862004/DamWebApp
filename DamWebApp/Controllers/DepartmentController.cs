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
    }
}
