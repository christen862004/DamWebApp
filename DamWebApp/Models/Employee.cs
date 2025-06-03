using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DamWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3,ErrorMessage ="NAme Must Be More Than 3 Char")]
        [MaxLength(25)]
        public string Name { get; set; }

        //[Range(6000,50000,ErrorMessage ="Salary Must be Between  6000 : 5000")]
        //[GreaterThan(7000,XYZ ="asd")]
        [Remote("CheckSalary","Employee",AdditionalFields = "Name")]
        public int Salary { get; set; }

        //[DataType(DataType.EmailAddress)]
        [Unique]
        public string? Email { get; set; }//unqiue

        //[Required]
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image must be jpg or png ex: example@jpg")]//chri.jpg
        public string? ImageURL { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }//Forenkey

        
        public Department? Department { get; set; }//Navigation PRoperty
        
    }
}
