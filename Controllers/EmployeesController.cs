using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Management_System.Model;  
using Employee_Management_System.Data;


namespace Employee_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }


        //GET /api/employees → Get all employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {

            return await _context.Employee_Management_System.ToListAsync();
        }


        //GET /api/employees/{id → Get employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _context.Employee_Management_System.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        // POST /api/employees → Add a new employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            _context.Employee_Management_System.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee added successfully" });
        }


        //PUT /api/employees/{id} → Update an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var existing = await _context.Employee_Management_System.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = employee.Name;
            existing.Position = employee.Position;
            existing.Department = employee.Department;
            existing.Salary = employee.Salary;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Employee updated successfully" });
        }



        //DELETE /api/employees/{id} → Delete an employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee_Management_System.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee_Management_System.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee_Management_System.Any(e => e.Id == id);
        }


    }
}
