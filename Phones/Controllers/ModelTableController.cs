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
        public ActionResult EditPhone(int? id)
        {
            List<Phone> phone;
            if (id != null)
                phone = new List<Phone> { db.Phones.Find(id) };
            else return HttpNotFound();

            List<SelectListItem> CompList = new List<SelectListItem>();
            foreach (var c in db.Companies)
            {
                if (phone.First().CompanyID!=c.ID) CompList.Add(new SelectListItem { Text = c.Name, Value = c.ID.ToString() });
                else CompList.Add(new SelectListItem { Text = c.Name, Value = c.ID.ToString(), Selected = true });
            }
            ViewData["CompanyID"] = CompList;

            return View(phone);
        }
        public ActionResult EditCompany(int? id)
        {
            List<Company> company;
            if (id != null)
                company = new List<Company> { db.Companies.Find(id) };
            else return HttpNotFound();

            return View(company);
        }
    }
}