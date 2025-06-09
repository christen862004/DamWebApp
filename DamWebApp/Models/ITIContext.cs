using Microsoft.EntityFrameworkCore;

namespace DamWebApp.Models
{
    public class ITIContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //DbContextOptions
        //Sql server
        //Server NAme  .
        //Authan.
        //dataBase name
        //public ITIContext():base()
        //{
        //}
        //inject DbCotextOption
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=D3M;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
