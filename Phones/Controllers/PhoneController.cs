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
        ModelsContext db;

        public PhoneController(ModelsContext context)
        {
            db = context;
        }

        // GET api/<controller>
        public IEnumerable<Phone> GetPhones()
        {
            return db.Phones.ToList();
        }

        // GET api/<controller>/5
        public Phone GetPhone(int id)
        {
            return db.Phones.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult AddPhone(Phone phone)
        {
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
                var phoneDB = db.Phones.Find(phone.ID);

                db.Entry(phoneDB).CurrentValues.SetValues(phone);
                db.Entry(phoneDB).State = EntityState.Modified;
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