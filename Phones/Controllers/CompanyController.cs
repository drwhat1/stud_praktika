﻿using System;
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
            return Json(db.Companies);
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
        public IHttpActionResult EditCompany(int id, Company company)
        {
            if (company.DateOfFoundation.Date == new DateTime(1,1,1))
                ModelState.AddModelError("company.DateOfFoundation", "Требуется поле Дата основания");
            else if (company.DateOfFoundation.Year < 1753)
                ModelState.AddModelError("company.DateOfFoundation", "Год не может быть меньше 1753");
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }
    }
}
