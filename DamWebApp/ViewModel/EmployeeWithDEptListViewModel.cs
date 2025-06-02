using DamWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DamWebApp.ViewModel
{
    public class EmployeeWithDEptListViewModel
    {
        //hide some property = change column name 
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }
        //Employee Email
        [Display(Name ="Employee Name")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? ImageURL { get; set; }

        
        public int DepartmentId { get; set; }
        
        public List<Department> DeptList { get; set; }

    }
}

/*
 phone
 datetie
 image
 email
 password
 number
 */



