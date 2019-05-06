using jabil_test.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNet.Core;
using System;
using DataTables.AspNet.AspNetCore;
using jabil_test.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jabil_test.Controllers
{
    public class PartNumberController: CRUDController<PartNumber>
    {
        public PartNumberController(MaterialsContext context) : base(context)
        {
        }

        public override IActionResult DataTable(IDataTablesRequest request)
        {
            var data = _context.PartNumbers.Include(p => p.Customer);

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(_item =>
                    _item.Name.Contains(request.Search.Value)
                    || _item.Customer.Name.Contains(request.Search.Value)
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
            ViewData["Customers"] = new SelectList(_context.Customers.Where(c => c.Available).ToList(), "Pkcustomer", "Name");

            return View();
        }

        public override IActionResult Edit(int id)
        {
            var partNumber = _context.PartNumbers.Find(id);

            if (partNumber == null)
            {
                return NotFound();
            }

            ViewData["Customers"] = new SelectList(_context.Customers.Where(c => c.Available).ToList(), "Pkcustomer", "Name");

            return View(partNumber);
        }

        public override IActionResult Store(PartNumber partNumber)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            _context.PartNumbers.Add(partNumber);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public override IActionResult Update(PartNumber partNumber)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = partNumber.PkpartNumber });
            }

            _context.PartNumbers.Update(partNumber);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public override IActionResult Delete(int id)
        {
            var partNumber = _context.PartNumbers.Find(id);

            _context.PartNumbers.Remove(partNumber);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
