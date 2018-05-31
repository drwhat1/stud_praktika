using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Phones.Models
{
    public class Company
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Штаб-квартира")]
        public string Location { get; set; }

        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]
        public DateTime DateOfFoundation { get; set; }

        [Required]
        [Display(Name = "Активно")]
        public bool Active { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}