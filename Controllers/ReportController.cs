using System;
using System.Linq;
using jabil_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace jabil_test.Controllers
{
    public class ReportController: BaseController
    {
        public ReportController(MaterialsContext context): base(context)
        {
        }

        private IEnumerable<PartReport> Report(PartReportSearch search = null)
        {
            var command = "EXECUTE [dbo].[FindParts] @PKPartNumber={0},@PartNumber={1},@PKCustomer={2},@Customer={3},@Available={4};";

            var parameters = new object[] {
                search?.PKPartNumber,
                search?.PartNumber,
                search?.PKCustomer,
                search?.Customer,
                search?.Available == "on",
            };

            return _context.PartReport.FromSql(command, parameters).ToList();
        }

        public IActionResult Index(PartReportSearch search = null)
        {
            var report = Report(search);

            ViewData["Search"] = search ?? new PartReportSearch();

            return View(report);
        }

        public IActionResult Excel(PartReportSearch search = null)
        {
            var now = DateTime.Now;

            var report = Report(search);

            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(report), (typeof(DataTable)));

            using (var stream = new MemoryStream())
            {
                var document = SpreadsheetDocument.Create(stream: stream,
                                                          type: SpreadsheetDocumentType.Workbook,
                                                          autoSave: true);

                var workbookPart = document.AddWorkbookPart();
                var workbook = workbookPart.Workbook = new Workbook();
                var sheetsElement = new Sheets();
                workbook.AppendChild(sheetsElement);

                WorksheetPart newWorksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                newWorksheetPart.Worksheet = new Worksheet(sheetData);

                string relationshipId = workbookPart.GetIdOfPart(newWorksheetPart);

                var name = "PartNumber Report";

                Sheet sheet = new Sheet() { Id = relationshipId, SheetId = 1, Name = name };

                Row headerRow = new Row();

                List<string> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();
                    foreach (String col in columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                sheetsElement.AppendChild(sheet);

                workbook.Save();
                document.Save();

                document.Close();

                var bytes = stream.ToArray();

                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"PartNumberReport_{now}.xlsx");
            }
        }
    }
}
