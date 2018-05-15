using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Phones.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}