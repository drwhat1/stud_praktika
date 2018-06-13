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
        ModelsContext db;

        public CompanyController(ModelsContext context)
        {
            db = context;
        }

        public IEnumerable<Company> GetCompanies()
        {
            return db.Companies.ToList();
        }

        public Company GetCompany(int id)
        {
            return db.Companies.Find(id);
        }

        [HttpPost]
        public IHttpActionResult AddCompany(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult EditCompany(int id, Company company)
        {
            if (ModelState.IsValid)
            {
                var companyDB = db.Companies.Find(company.ID);

                db.Entry(companyDB).CurrentValues.SetValues(company);
                db.Entry(companyDB).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCompany(int? id)
        {
            Company company = db.Companies.Find(id);
            if (company != null)
            {
                db.Companies.Remove(company);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }
    }
}
