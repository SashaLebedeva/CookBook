using CookBookAdoWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBookAdoWeb.Controllers
{
    public class UnitController : Controller
    {
        Actions act = new Actions();
        // GET: Unit
        public ActionResult Index()
        {
            List<Unit>units =act.getAllUnit();
            return View(units);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public ActionResult Create(Unit unit)
        {
            if (ModelState.IsValid)
            {
                int result = act.addUnit(unit.NameUnit);
            }
            return Redirect("/Unit/Index");
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Unit unit = act.getUnit(id);
            return View(unit);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            act.deleteUnit(id);
            return Redirect("/Unit/Index");
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Unit tod = act.getUnit(id);
            return View(tod);
        }

        [HttpPost]
        public ActionResult Edit(Unit unit)
        {
            act.updateUnit(unit.IdUnit, unit.NameUnit);
            return Redirect("/Unit/Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Unit unit = act.getUnit(id);
            return View(unit);
        }
















    }
}