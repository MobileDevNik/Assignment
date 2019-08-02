using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentApi.Data;
using AssignmentApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        AssignmentDbContext _assignmentDbContext;

        public DepartmentsController(AssignmentDbContext context)
        {
            _assignmentDbContext = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return _assignmentDbContext.departments;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            var department = _assignmentDbContext.departments.Find(id);
            return department;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IEnumerable<Department> getComplete()
        {
            var departments = _assignmentDbContext.departments.Include("employees");
            return departments;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            _assignmentDbContext.departments.Add(department);
            _assignmentDbContext.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Department value)
        {
            var department = _assignmentDbContext.departments.Find(id);
            if (department != null)
            {
                department.DepartmentName = value.DepartmentName;
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
            var departments = _assignmentDbContext.departments.Include("employees");
            Department department = departments.FirstOrDefault(x => x.Id == id);
            if (department != null)
            {
                var empCount = department.employees.Count;
                for (int i = 0; i < empCount; i++)
                {
                    var emp = department.employees.FirstOrDefault();
                    _assignmentDbContext.employee.Remove(emp);
                    department.employees.Remove(emp);
                }
                _assignmentDbContext.departments.Remove(department);
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
