using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        HrContext context = new HrContext();

        public EmployeeController(ILogger<EmployeeController> logger, HrContext context)
        {
            _logger = logger;
            context = context;
        }

        public IActionResult Index()
        {
            try 
            {

                var lstEmployees = context.Employees.ToList();
                return View(lstEmployees);
            }
            catch (Exception) 
            {
                return View(new List<Employee>());
            }
        }

        public IActionResult Create()
        {
            return View(new Employee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");  
        }

        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);  // Pre-populate the form with the current employee details
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(employee);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!context.Employees.Any(e => e.Id == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }



        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
