using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSampleProject.Models;

namespace WebApiSampleProject.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        IList<Employee> employees = new List<Employee>()
        {
            new Employee()
                {
                    EmployeeId = 1, EmployeeName = "Mukesh Kumar", Address = "New Delhi", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 2, EmployeeName = "Banky Chamber", Address = "London", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Rahul Rathor", Address = "Laxmi Nagar", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "YaduVeer Singh", Address = "Goa", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Manish Sharma", Address = "New Delhi", Department = "HR"
                },
        };

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IList<Employee> GetAllEmployees()
        {
            //Return list of all employees  
            return employees;
        }

        /// <summary>
        /// Gets an employee by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                var message = ($"Employee with id = {id} not found");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        /// <summary>
        /// Gets an employee by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [Route("{name}")]
        [HttpGet]
        public IHttpActionResult GetEmployeeByName(string name)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeName.ToLower().Contains(name.ToLower()));
            if (employee == null)
            {
                var message = ($"Employee with name = {name} not found");
                HttpError err = new HttpError(message);
                //return Content(HttpStatusCode.NotFound, message);
                return NotFound();
            }
            return Ok<Employee>(employee);
        }
    }
}
