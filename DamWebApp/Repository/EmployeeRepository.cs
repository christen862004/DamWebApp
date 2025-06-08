using DamWebApp.Models;

namespace DamWebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository//,IRepository<Employee>
    {
        //CRUD : Create  - Read - Update - Delete
        ITIContext context;
        public EmployeeRepository()
        {
            context = new ITIContext();
        }

        public void Add(Employee entity)
        {
            context.Employees.Add(entity);
        }

        public void Delete(int id)
        {
            Employee empFromDb = GetById(id);
            context.Employees.Remove(empFromDb);
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            Employee empFromDdb=GetById(entity.Id);
            empFromDdb.Name=entity.Name;
            empFromDdb.Salary=entity.Salary;
            empFromDdb.Email=entity.Email;
            empFromDdb.ImageURL=entity.ImageURL;
            empFromDdb.DepartmentId=entity.DepartmentId;
        }
    }
}
