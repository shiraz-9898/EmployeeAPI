using CrudApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmpDbContext _context;
        public EmployeesController(EmpDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _context.Employees.Find(id);
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, Employee emp)
        {

            if(emp.Id != id)
            {
                return BadRequest();
            }
           
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var data = _context.Employees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(data);
            _context.SaveChanges();
            return Ok("Data deleted successfully");
        }
    }
}
