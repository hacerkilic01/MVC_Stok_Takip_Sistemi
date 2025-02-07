using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class UnitController : Controller
    {
        public MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1();
        public LinkedList <Unit> UnitLinkedList = new LinkedList <Unit>();
        public ActionResult Index()
        {
            var UnitFromdb = db.Units.ToList();
            foreach (var unit in UnitFromdb) { 
            UnitLinkedList.AddLast(unit);
            }

            return View(UnitLinkedList.ToList());
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
        public void UpdateUnit(Unit updatedUnit)
        {
            var node = UnitLinkedList.First; 
            {
                if (node.Value.ID == updatedUnit.ID) 
                {
                    node.Value = updatedUnit;
                    //break;
                }
                node = node.Next; 
            }
        }
        public ActionResult UpdateInformation(Unit p) {
            var model= db.Units.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View("Save",model);
        }
        public ActionResult DeleteUnit(Unit p)
        {
            var model = db.Units.Find(p.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Delete(Unit p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}