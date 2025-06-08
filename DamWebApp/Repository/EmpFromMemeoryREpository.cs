using DamWebApp.Models;

namespace DamWebApp.Repository
{
    public class EmpFromMemeoryREpository : IEmployeeRepository
    {
        List<Employee> Employees;
        public EmpFromMemeoryREpository()
        {
            Employees = new List<Employee>() {
            new(){Id=1,Name="ahmed"},
            new(){Id=2,Name="basma"}
            };
        }
        public List<Employee> GetAll()
        {
            return Employees;
        }



        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
