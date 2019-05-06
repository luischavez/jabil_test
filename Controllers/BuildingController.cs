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
    public class BuildingController : CRUDController
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
            return View();
        }

        public override IActionResult Edit(int id)
        {
            return View();
        }

        public override IActionResult Store()
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            var building = _context.Buildings.Find(id);

            _context.Buildings.Remove(building);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
