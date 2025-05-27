namespace DamWebApp.Models
{
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new() {
                new(){Id=1,Name="ahmed",Address="alex",ImageUrl="m.png"},
                new(){Id=2,Name="Sara",Address="alex",ImageUrl="2.jpg"},
                new(){Id=3,Name="Mohamed",Address="alex",ImageUrl="m.png"},
                new(){Id=4,Name="Samar",Address="alex",ImageUrl="2.jpg"},
            };
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetByID(int id)
        {
            return students.FirstOrDefault(s=>s.Id==id);
        }
        //............
    }
}
