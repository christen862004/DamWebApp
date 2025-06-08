using DamWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DamWebApp.Repository
{
    public class DepartmentRepository :IDepartmentRepository// IRepository<Department>
    {
        //CRUD : Create  - Read - Update - Delete
        ITIContext context;
        public DepartmentRepository()
        {
            context=new ITIContext();
        }
        public void Add(Department entity)
        {
           context.Departments.Add(entity);
        }

        public void Delete(int id)
        {
            Department dept=GetById(id);
            context.Departments.Remove(dept);   
        }

        public List<Department> GetAll()
        {
            return  context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Department entity)
        {
            Department deptfromDb=GetById(entity.Id);
            deptfromDb.Name=entity.Name;
            deptfromDb.ManagerName=entity.ManagerName;
        }
    }
}
