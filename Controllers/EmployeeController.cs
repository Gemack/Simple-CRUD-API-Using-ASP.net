using firstA.Data;
using firstA.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _db;
        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _db.Employees.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            return  employee == null ? NotFound(): Ok(employee);
        
        }
        [HttpPost]
        public async Task<IActionResult> create(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = employee.Id}, employee);
        }
        [HttpPut("id")]
        public async Task<IActionResult> update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            _db.Entry(employee).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
            
        }

        [HttpDelete("id")] 
        public async Task<IActionResult> delete(int id)
        {
            var employeeDel = await _db.Employees.FindAsync(id);
            if(employeeDel == null)
            {
                return NotFound();
            }
            _db.Remove(employeeDel);
            await _db.SaveChangesAsync();

            return NoContent();
        }

   
     
      
        

    }
}
