using jabil_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.EntityFrameworkCore;
using jabil_test.Extensions;

namespace jabil_test.Controllers
{
    public class BuildingController : CRUDController<Building>
    {
        public BuildingController(MaterialsContext context) : base(context)
        {
        }

        public override IActionResult DataTable(IDataTablesRequest request)
        {
            var data = _context.Buildings;

            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
                : data.Where(_item =>
                    _item.Name.Contains(request.Search.Value)
                    || (_item.Available ? "true" : "false").Contains(request.Search.Value));

            var orderColums = request.Columns.Where(x => x.Sort != null);

            // see Extensions/DataTableExtensions
            var dataPage = filteredData.OrderBy(orderColums).Skip(request.Start).Take(request.Length).ToList();

            var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

            return new DataTablesJsonResult(response, true);
        }

        /*
         * List of buildings.       
         */
        public override IActionResult Index()
        {
            return View();
        }

        /*
         * Display a form to create new buildings.
         */
        public override IActionResult Create()
        {
            return View();
        }

        /*
         * Display a edit form.
         */
        public override IActionResult Edit(int id)
        {
            var building = _context.Buildings.Find(id);

            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        /*
         * Stores new building.
         */
        public override IActionResult Store(Building building)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            _context.Buildings.Add(building);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /*
         * Update building data.
         */
        public override IActionResult Update(Building building)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = building.Pkbuilding });
            }

            _context.Buildings.Update(building);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        /*
         * Delete building.
         */
        public override IActionResult Delete(int id)
        {
            var building = _context.Buildings.Find(id);

            _context.Buildings.Remove(building);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
