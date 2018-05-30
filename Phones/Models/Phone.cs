using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Phones.Models
{
    public class Phone
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Компания")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}