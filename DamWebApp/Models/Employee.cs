using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DamWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Salary { get; set; }
        
        public string? Email { get; set; }

        public string? ImageURL { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }//Forenkey

        public Department Department { get; set; }//Navigation PRoperty
        
    }
}
