using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Phones.Models;
using System.Data.Entity;

namespace Phones.Controllers
{
    public class CompanyController : ApiController
    {
        ModelsContext db = new ModelsContext();

        public IHttpActionResult GetCompanies()
        {
            return Json(db.Companies.ToList());
        }

        public IHttpActionResult GetCompany(int id)
        {
            return Json(db.Companies.Find(id));
        }

        [HttpPost]
        public void AddCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void EditCompany(int id, Company company)
        {
            if (id == company.ID)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
