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
        public IEnumerable<Phone> GetPhones()
        {
            return db.Phones;
        }

        // GET api/<controller>/5
        public Phone GetPhone(int id)
        {
            return db.Phones.Find(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void AddPhone(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void EditPhone(int id, Phone phone)
        {
            if (id == phone.ID)
            {
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}