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
        public ActionResult EditPhone(int? id)
        {
            Phone phone = new Phone();
            if (id != null)
                phone = db.Phones.Find(id);
            else return HttpNotFound();

            SelectList CompList = new SelectList(db.Companies,"ID","Name",phone.CompanyID);
            ViewData["CompanyID"] = CompList;

            return View(phone);
        }
        public ActionResult EditCompany(int? id)
        {
            Company company = new Company();
            if (id != null)
                company = db.Companies.Find(id);
            else return HttpNotFound();

            return View(company);
        }
    }
}