using CookBookAdoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Controllers
{
    public class IngredientController : Controller
    {
        Actions act = new Actions();
        // GET: Ingredient
        public ActionResult Index()
        {
            List<Ingredient> ingr = act.getAllIngr();
            return View(ingr);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            List<Unit> units = act.getAllUnit();
            ViewBag.some = units;
            Ingredient ingr = new Ingredient();
            return View(ingr);
        }

        [HttpPost]
        public ActionResult Create(Ingredient ingr)
        {
             act.addIngredient(ingr.Name, ingr.Price, ingr.Unit);
            return Redirect("/Ingredient/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Ingredient ingr = act.getIngredient(id);
            return View(ingr);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            act.deleteIngredient(id);
            return Redirect("/Ingredient/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Unit> units = act.getAllUnit();
            ViewBag.units = units;

            Ingredient ingr = act.getIngredient(id);
            ViewBag.unit = ingr.Unit;
            return View(ingr);
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
            Ingredient ingr = act.getIngredient(id);
            return View(ingr);
        }









    }
}