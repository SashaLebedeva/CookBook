using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Models
{
    public class TypeOfDish
    {
        [HiddenInput(DisplayValue = false)]
        public int IdType { get; set; }
        [Required]
        [Display(Name = "Типы блюд")]
        public string NameType { get; set; }
    }
}