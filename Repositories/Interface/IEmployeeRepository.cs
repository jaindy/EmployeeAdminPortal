using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAsync();
        Task<bool> DeleteAsync(Guid id);
        Task<Employee> GetByIdAsync(Guid id);
        Task<Employee> UpdateAsync(Employee employee);
    }
}
