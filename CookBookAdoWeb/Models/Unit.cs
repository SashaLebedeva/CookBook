using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Models
{
    public class Unit
    {
        [HiddenInput(DisplayValue = false)]
        public int IdUnit { get; set; }
        [Required]
        [Display(Name = "Единицы измерения")]
        public string NameUnit { get; set; }
    }
}