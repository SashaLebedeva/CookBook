using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CookBookAdoWeb.Models
{
    public class Dish
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Блюда")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public Decimal Price { get; set; }
        [Display(Name = "Тип")]
        public string TypeOfDish { get; set; }
    }
}