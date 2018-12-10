using CookBookAdoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Controllers
{
    public class TypeOfDishController : Controller
    {
        Actions act = new Actions();
        // GET: TypeOfDish
        public ActionResult Index()
        {
            
            List<TypeOfDish> allType = act.getAllType();

            return View(allType);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            TypeOfDish tod = act.getTypeOfDish(id);
            return View(tod);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            act.deleteType(id);
            return Redirect("/TypeOfDish/Index");
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            TypeOfDish tod = new TypeOfDish();
            return View(tod);
        }

        [HttpPost]
        public ActionResult Create(TypeOfDish tod)
        {
            if (ModelState.IsValid)
            {
                string sqlExpr = String.Format("INSERT INTO TypeOfDish (Name_Type) VALUES ('{0}')", tod.NameType);
                int result = act.addType(sqlExpr);
            }
            return Redirect("/TypeOfDish/Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //TypeOfDish tod = new TypeOfDish();
            TypeOfDish tod = act.getTypeOfDish(id);
            return View(tod);
        }

        [HttpPost]
        public ActionResult Edit(TypeOfDish typeOfDish)
        {
            act.updateType(typeOfDish.IdType, typeOfDish.NameType);
            return Redirect("/TypeOfDish/Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TypeOfDish tod = act.getTypeOfDish(id);
            return View(tod);
        }





    }
}