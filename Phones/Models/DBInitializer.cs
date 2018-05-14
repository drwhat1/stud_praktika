using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Phones.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<ModelsContext>
    {
        protected override void Seed(ModelsContext context)
        {
            context.Companies.Add(new Company()
            {
                Name = "Apple",
                Location = "Купертино, Калифорния, США",
                DateOfFoundation = new DateTime(1976, 4, 1).Date,
                Active = true
            });
            context.Companies.Add(new Company()
            {
                Name = "Samsung",
                Location = "Республика Корея, Сувон",
                DateOfFoundation = new DateTime(1938, 5, 12).Date,
                Active = true
            });
            context.Phones.Add(new Phone()
            {
                Name = "IPhone 4",
                CompanyID = 1
            });
            context.Phones.Add(new Phone()
            {
                Name = "Samsung J5",
                CompanyID = 2
            });

            base.Seed(context);
        }
    }
}