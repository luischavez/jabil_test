using System;
using jabil_test.Models;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;

namespace jabil_test.Controllers
{
    /*
     * Abstract controller with CRUD operations.   
     */   
    public abstract class CRUDController<T> : BaseController
    {
        protected CRUDController(MaterialsContext context) : base(context)
        {
        }

        /*
         * Obtains datatable json data.
         */
        public abstract IActionResult DataTable(IDataTablesRequest request);

        /*
         * List of elements.       
         */       
        public abstract IActionResult Index();

        /*
         * Display a form to create new elements.
         */
        public abstract IActionResult Create();

        /*
         * Stores new element.
         */
        public abstract IActionResult Store(T t);

        /*
         * Display a edit form.
         */
        public abstract IActionResult Edit(int id);

        /*
         * Update element data.
         */
        public abstract IActionResult Update(T t);

        /*
         * Delete element.
         */
        public abstract IActionResult Delete(int id);
    }
}
