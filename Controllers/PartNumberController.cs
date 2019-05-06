using jabil_test.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DataTables.AspNet.Core;
using System;
using DataTables.AspNet.AspNetCore;
using jabil_test.Extensions;

namespace jabil_test.Controllers
{
    public class PartNumberController: CRUDController
    {
        public PartNumberController(MaterialsContext context) : base(context)
        {
        }

        public override IActionResult DataTable(IDataTablesRequest request)
        {
            var data = _context.PartNumbers;

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
            return View();
        }

        public override IActionResult Edit()
        {
            return View();
        }

        public override IActionResult Store()
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Update()
        {
            throw new System.NotImplementedException();
        }

        public override IActionResult Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
