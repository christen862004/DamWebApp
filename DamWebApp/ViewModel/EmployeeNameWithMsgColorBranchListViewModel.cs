namespace DamWebApp.ViewModel
{
    public class EmployeeNameWithMsgColorBranchListViewModel
    {
        //1) deont send all model property + Hide Table struct
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        //3) Add Extra Info
        public string  Message { get; set; }
        public int Temp { get; set; }
        public string Color { get; set; }
        public List<string> Branches { get; set; }
    }
}
