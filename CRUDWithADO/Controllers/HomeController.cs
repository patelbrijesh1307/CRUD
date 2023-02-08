using CRUDWithADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWithADO.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBContext EmployeeDB = new EmployeeDBContext();
        // GET: Home
        public ActionResult Index()
        {
            List<Employee> emp = EmployeeDB.GetEmployees();
            return View(emp);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);
                    if (check == true)
                    {
                        TempData["InsertEmployee"] = "Employee Inseted !!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["InsertEmployee"] = "Employee Not Inseted !!";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
           
        }

        public ActionResult Edit(int id)
        {
            EmployeeDBContext employeeDB = new EmployeeDBContext();
            var row = employeeDB.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.UpdateEmployee(employee);
                if (check == true)
                {
                    TempData["UpdateEmployee"] = "Employee Data Updated !!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateEmployee"] = "Employee Data Not Updated !!";
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            EmployeeDBContext employeeDB = new EmployeeDBContext();
            var row = employeeDB.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        public ActionResult Delete(int id)
        {
            EmployeeDBContext employeeDB = new EmployeeDBContext();
            var row = employeeDB.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.DeleteEmployee(id);
                if (check == true)
                {
                    TempData["DeleteEmployee"] = "Employee Data Delete !!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteEmployee"] = "Employee Data Not Delete !!";
                }
            
            return View();
        }
    }
}