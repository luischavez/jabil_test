using System;
using jabil_test.Models;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;

namespace jabil_test.Controllers
{
    public abstract class CRUDController : BaseController
    {
        protected CRUDController(MaterialsContext context) : base(context)
        {
        }

        public abstract IActionResult DataTable(IDataTablesRequest request);

        public abstract IActionResult Index();

        public abstract IActionResult Create();

        public abstract IActionResult Store();

        public abstract IActionResult Edit(int id);

        public abstract IActionResult Update(int id);

        public abstract IActionResult Delete(int id);
    }
}
