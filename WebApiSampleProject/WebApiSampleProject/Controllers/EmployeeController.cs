using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSampleProject.Models;

namespace WebApiSampleProject.Controllers
{
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
        public Employee GetEmployeeDetails(int id)
        {
            //Return a single employee detail  
            var employee = employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }

        /// <summary>
        /// Gets an employee by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Employee GetEmployeeByName(string name)
        {
            var employee = employees.FirstOrDefault(e => e.EmployeeName.ToLower().Contains(name.ToLower()));
            if(employee == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            return employee;
        }
    }
}
