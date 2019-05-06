using jabil_test.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNet.Core;
using System;
using DataTables.AspNet.AspNetCore;
using Microsoft.EntityFrameworkCore;
using jabil_test.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace jabil_test.Controllers
{
    public class CustomerController: CRUDController<Customer>
    {
        public CustomerController(MaterialsContext context) : base(context)
        {

        }

        public override IActionResult DataTable(IDataTablesRequest request)
        {
            var data = _context.Customers.Include(c => c.Building);

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(_item => 
                    _item.Name.Contains(request.Search.Value) 
                    || _item.Prefix.Contains(request.Search.Value)
                    || _item.Building.Name.Contains(request.Search.Value)
                    || (_item.Available ? "true" : "false").Contains(request.Search.Value));

            var orderColums = request.Columns.Where(x => x.Sort != null);

            var dataPage = filteredData.OrderBy(orderColums).Skip(request.Start).Take(request.Length).ToList();

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, true);
        }

        public override IActionResult Index()
        {
            return View();
        }

        public override IActionResult Create()
        {
            ViewData["Buildings"] = new SelectList(_context.Buildings.Where(b => b.Available).ToList(), "Pkbuilding", "Name");

            return View();
        }

        public override IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            ViewData["Buildings"] = new SelectList(_context.Buildings.Where(b => b.Available).ToList(), "Pkbuilding", "Name");

            return View(customer);
        }

        public override IActionResult Store(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public override IActionResult Update(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = customer.Pkcustomer });
            }

            _context.Customers.Update(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public override IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
