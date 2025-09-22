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


        //POST /api/employees → Add a new employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            _context.Employee_Management_System.Add(employee); 
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }


        // PUT /api/employees/{id} → Update an existing employee 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest(); 
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); 
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound(); 
                }
                else
                {
                    throw; 
                }
            }

            return NoContent(); 
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
