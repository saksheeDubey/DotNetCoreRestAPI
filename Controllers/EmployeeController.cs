using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPICRUD.EmployeeData;
using RESTAPICRUD.Models;

namespace RESTAPICRUD.Controllers
{
    
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeData _empdata;
        public EmployeeController(IEmployeeData empdata)
        {
            _empdata = empdata;

        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_empdata.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employeeid = _empdata.GetEmployee(id);
            if (employeeid != null)
            {
                return Ok(employeeid);
            }
            else
            {
                return NotFound($"Mentioned employee id :{id} was not found");
            }
           
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employees employee)
        {
           _empdata.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.empid, employee);

        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult deleteEmployee (Guid id)
        {
            var employeeid = _empdata.GetEmployee(id);
            if(employeeid != null)
            {
                _empdata.deleteEmployee(employeeid);
                return Ok($"Mentioned ID :{id} has been deleted");
            }
            else
            {
                return NotFound($"Mentioned ID : {id} was not found");
            }
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditEmployee(Guid id , Employees employee)
        {
            var existingemployee = _empdata.GetEmployee(id);
            if(existingemployee != null)
            {
                employee.empid = existingemployee.empid;
                _empdata.EditEmployee(employee);
                return Ok("Editing has been done");

            }
            else
            {
                return NotFound("Mentioned id was not found");
            }
        }


    }
}