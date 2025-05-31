using DamWebApp.Models;

namespace DamWebApp.ViewModel
{
    public class EmployeeBranchListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public List<string> Branches { get; set; }
    }
}
