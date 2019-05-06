using System;
using System.Linq;
using jabil_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jabil_test.Controllers
{
    public class ReportController: BaseController
    {
        public ReportController(MaterialsContext context): base(context)
        {
        }

        public IActionResult Index(PartReportSearch search = null)
        {
            var command = "EXECUTE [dbo].[FindParts] @PKPartNumber={0},@PartNumber={1},@PKCustomer={2},@Customer={3},@Available={4};";

            var parameters = new object[] {
                search?.PKPartNumber,
                search?.PartNumber,
                search?.PKCustomer,
                search?.Customer,
                search?.Available == "on",
            };

            var partNumbers = _context.PartReport.FromSql(command, parameters).ToList();

            ViewData["Search"] = search ?? new PartReportSearch();

            return View(partNumbers);
        }

        public IActionResult Excel()
        {
            return null;
        }
    }
}
