using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Phones.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}