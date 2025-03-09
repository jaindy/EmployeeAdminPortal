using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext dBContext;

        public EmployeeRepository(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {

            await dBContext.Employees.AddAsync(employee);
            await dBContext.SaveChangesAsync();
            return employee;
        }

       public async Task<IEnumerable<Employee>> GetAsync()
        {
         return await dBContext.Employees.ToListAsync();
            
        }

        public async  Task<bool> DeleteAsync(Guid id)
        {
            var employee = await dBContext.Employees.FirstOrDefaultAsync(e=>e.Id==id);
            if (employee == null) { 
            return false;
            }
              dBContext.Employees.Remove(employee);
              await  dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = await dBContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
          var result =  await dBContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (result != null)
            {
                result.Name = employee.Name;
                result.Email = employee.Email;
                result.Phone = employee.Phone;
                result.Salary = employee.Salary;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
