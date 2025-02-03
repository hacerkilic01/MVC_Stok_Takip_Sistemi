using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class UnitController : Controller
    {
        MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1();
        public ActionResult Index()
        {
            return View(db.Units.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View("Save");
        }
        [HttpPost]
        public ActionResult Save(Unit p)
        {
            if (p.ID == 0)
            {
                db.Units.Add(p);
            }
            else
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateInformation(Unit p) {
            var model= db.Units.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View("Save",model);
        }
    }
}