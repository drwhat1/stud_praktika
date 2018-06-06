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

        [Required(ErrorMessage = "Требуется поле Название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Требуется поле Штаб-квартира")]
        [Display(Name = "Штаб-квартира")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Требуется поле Дата основания")]
        [Display(Name = "Дата основания")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime),"1-1-1753","31-12-2020",
            ErrorMessage = "Требуется дата из интервала [01.01.1753 - 31.12.2020]")]
        public DateTime? DateOfFoundation { get; set; }

        [Display(Name = "Активно")]
        public bool Active { get; set; }

        public virtual List<Phone> Phones { get; set; }
    }
}