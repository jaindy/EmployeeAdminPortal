using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDBContext : DbContext //inheritance
    {
        //ctor tab is used to create constructor
        /*    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
            {
                // ApplicationDBContext is required if multiple db context present otherwise it is optional   
            }
        */
        //ctrl + .
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
