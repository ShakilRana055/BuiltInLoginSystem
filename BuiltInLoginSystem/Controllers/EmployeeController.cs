using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuiltInLoginSystem.Data;
using BuiltInLoginSystem.EntityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuiltInLoginSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;
        public EmployeeController(AppDbContext _context)
        {
            context = _context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var employeeList = context.Employee.ToList();
            return View(employeeList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Employee modelEmployee )
        {
            var employee = context.Employee.ToList().Where( x => x.Id == modelEmployee.Id).FirstOrDefault();
            if(employee  != null)
            {
                employee.Name = modelEmployee.Name;
                employee.Email = modelEmployee.Email;
                employee.Address = modelEmployee.Address;
                employee.Phone = modelEmployee.Phone;
                context.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee()
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    Address = employee.Address,
                    Phone = employee.Phone,
                };
                context.Employee.Add(newEmployee);
                context.SaveChanges();
            }
            return View();
        }
    }
}
