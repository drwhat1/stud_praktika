using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phones.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public bool Active { get; set; }
    }
}