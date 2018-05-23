using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Phones.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Штаб-квартира")]
        public string Location { get; set; }

        [Display(Name = "Дата основания")]
        public DateTime DateOfFoundation { get; set; }

        [Required]
        [Display(Name = "Активно")]
        public bool Active { get; set; }

        public virtual IEnumerable<Phone> Phones { get; set; }
    }
}