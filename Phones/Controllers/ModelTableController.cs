using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phones.Models;

namespace Phones.Controllers
{
    public class ModelTableController : Controller
    {
        private ModelsContext db = new ModelsContext();
        // GET: PhonesTable
        public ActionResult Phones()
        {
            SelectList CompList = new SelectList(db.Companies, "ID", "Name");
            ViewData["CompanyID"] = CompList;
            return View(db.Phones.ToList());
        }
        public ActionResult Companies()
        {
            return View(db.Companies.ToList());
        }
    }
}