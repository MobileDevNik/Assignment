using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssignmentApi.Models;
using AssignmentApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AssignmentApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        AssignmentDbContext _assignmentDbContext;

        public EmployeesController(AssignmentDbContext context)
        {
            _assignmentDbContext = context;
        }


        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            List<Employee> employeeList = _assignmentDbContext.departments.SelectMany(x => x.employees).ToList();
            return employeeList;
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee emp = _assignmentDbContext.departments.SelectMany(parent => parent.employees)
                             .FirstOrDefault(child => child.Id == id);
            return emp;
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee value)
        {
            Employee emp = _assignmentDbContext.departments.SelectMany(parent => parent.employees)
                            .FirstOrDefault(child => child.Id == id);
            if (emp != null)
            {
                emp.EmployeeName = value.EmployeeName;
                _assignmentDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _assignmentDbContext.departments.FirstOrDefault(e => e.employees
                               .Any(a => a.Id == id));
            Employee emp = _assignmentDbContext.employee.Find(id);
            if (emp != null)
            {
                _assignmentDbContext.employee.Remove(emp);
                department.employees.Remove(emp);
                _assignmentDbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
           
        }
    }
}
