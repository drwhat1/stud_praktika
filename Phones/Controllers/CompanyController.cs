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

        public IEnumerable<Company> GetCompanies()
        {
            return db.Companies;
        }

        public Company GetCompany(int id)
        {
            return db.Companies.Find(id);
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
            if (id == company.ID && ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
