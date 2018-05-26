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
    public class PhoneController : ApiController
    {
        ModelsContext db = new ModelsContext();
        
        // GET api/<controller>
        public IHttpActionResult GetPhones()
        {
            return Json(db.Phones);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetPhone(int id)
        {
            return Json(db.Phones.Find(id));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult AddPhone(Phone phone)
        {
            if (phone.CompanyID == 0)
            {
                ModelState.Remove("phone.CompanyID");
                ModelState.AddModelError("phone.CompanyID", "Выберите компанию.");
            }

            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult EditPhone(int id, Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult DeletePhone(int? id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone != null)
            {
                db.Phones.Remove(phone);
                db.SaveChanges();
                return Ok();
            }
            else return BadRequest();
        }
    }
}