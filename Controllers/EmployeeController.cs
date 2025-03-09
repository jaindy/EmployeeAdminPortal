using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Filter;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        [CustomExceptionFilter]

        public async Task<IActionResult> GetAllEmployees()
        {
            throw new System.Exception("This is buildin exception");
           var empl= await employeeRepository.GetAsync();
            return Ok(empl);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            //seperation of concern
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name, //modularity
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,

            };
            await employeeRepository.CreateAsync(employeeEntity);

            return Created();

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await employeeRepository.DeleteAsync(id);
            if (!employee)
            {
                return NotFound();
            }
       
            return NoContent();
        }


   
           [HttpGet]
           [Route("{id:guid}")]
           public async Task<IActionResult> GetById(Guid id)
           {
              var employee= await employeeRepository.GetByIdAsync(id);
               if (employee == null)
               {
                   return NotFound();
               }
               return Ok(employee);
           }     
     

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Salary = updateEmployeeDto.Salary;  
            employee.Phone = updateEmployeeDto.Phone;

            await employeeRepository.UpdateAsync(employee);
            return Ok(employee);

        }
     
    }
}
/*

   [HttpPost]
     public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) {
         //seperation of concern
         var employeeEntity = new Employee() { 

             Name = addEmployeeDto.Name, //modularity
             Email = addEmployeeDto.Email,
             Phone = addEmployeeDto.Phone,
             Salary = addEmployeeDto.Salary,

         };

        dBContext.Employees.Add(employeeEntity);
        dBContext.SaveChanges(); //this ensure data added to table
                                 //    return Ok(employeeEntity); 
        return Created();

     }

     [HttpDelete]
     [Route("{id:guid}")]
     public IActionResult DeleteEmployee(Guid id) {
         var employee = dBContext.Employees.Find(id);
         if (employee == null) {
             return NotFound();
         }
         dBContext.Employees.Remove(employee);
         dBContext.SaveChanges();
         return Ok();    
     }
*/

/* dbcontext in same controller
 
    /*
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) {
            //seperation of concern
            var employeeEntity = new Employee() { 

                Name = addEmployeeDto.Name, //modularity
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
            
            };
                
           dBContext.Employees.Add(employeeEntity);
           dBContext.SaveChanges(); //this ensure data added to table
                                    //    return Ok(employeeEntity); 
           return Created();
  
        }

   [HttpPatch]
   [Route("{id:guid}")]
   public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDto updateEmployeeDto) 
   {
       var employee = dBContext.Employees.Find(id);
       if (employee == null) { 
           return NotFound();
       }
       employee.Name = updateEmployeeDto.Name;
       employee.Email = updateEmployeeDto.Email;   
     //  employee.Salary = updateEmployeeDto.Salary;  
     //  employee.Phone = updateEmployeeDto.Phone;

       dBContext.SaveChanges();
       return Ok(employee);    
   }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dBContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Salary = updateEmployeeDto.Salary;  
            employee.Phone = updateEmployeeDto.Phone;

            dBContext.SaveChanges();
            return Ok(employee);

        }
 /*   [HttpGet]
        public IActionResult GetAllEmployees()
        {
           var allEmployees= dBContext.Employees.ToList();
            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
           var employee= dBContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
*/
