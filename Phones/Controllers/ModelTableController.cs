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
            return View(db.Phones.ToList());
        }
        public ActionResult Companies()
        {
            return View(db.Companies.ToList());
        }
        public ActionResult AddPhone()
        {
            List<SelectListItem> CompList = new List<SelectListItem>();
            foreach (var c in db.Companies)
            {
                CompList.Add(new SelectListItem { Text=c.Name, Value=c.ID.ToString() });
            }
            ViewData["CompanyID"] = CompList;
            return View();
        }
        public ActionResult AddCompany()
        {
            return View();
        }
    }
}