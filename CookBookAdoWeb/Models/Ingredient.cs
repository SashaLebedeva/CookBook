using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Models
{
    public class Ingredient
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ингредиент")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public Decimal Price { get; set; }
        [Display(Name = "Ед Изм")]
        public string Unit { get; set; }
    }
}