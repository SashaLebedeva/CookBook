using CookBookAdoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Controllers
{
    public class DishesController : Controller
    {
        Actions act = new Actions();
        // GET: Dishes
        public ActionResult Index()
        {
            List<Dish> allDishes = act.getAllDishes();

            return View(allDishes);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            List<TypeOfDish> types = act.getAllType();
            ViewBag.types = types;
            Dish Dish = new Dish();
            return View(Dish);
        }

        [HttpPost]
        public ActionResult Create(Dish dish)
        {
            if (dish.Price<0)
            {
                ModelState.AddModelError("Цена", "Меньше нуля");
            }

            if (ModelState.IsValid)
            {
                act.addDish(dish.Name, dish.Price, dish.TypeOfDish);
            }

            return Redirect("/Dishes/Index");
        }

        

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Dish dish = act.getDish(id);
            return View(dish);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            act.deleteDish(id);
            return Redirect("/Dishes/Index");
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<TypeOfDish> type = act.getAllType();
            ViewBag.type = type;

            Dish dish = act.getDish(id);
            ViewBag.unit = dish.TypeOfDish;
            return View(dish);
        }

        [HttpPost]
        public ActionResult Edit(Ingredient ingr)
        {

            act.updateIngredient(ingr.Id, ingr.Name, ingr.Price, ingr.Unit);
            return Redirect("/Ingredient/Index");
        }












        [HttpGet]
        public ActionResult Details(int id)
        {
            Dish dish = act.getDish(id);
            return View(dish);
        }



    }
}