using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1 ();
        public ActionResult Index()
        {
            var model =db.Brands.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Brand();
            List<SelectListItem> list =new List<SelectListItem> (
                from x in db.Categories select new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.CategoryName
                }
                ).ToList();
            ViewBag.l =list;
            return View();
        }
        [HttpPost]
        public ActionResult Add (Brand m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", m.CategoryID); //Dropdown
                return View();

            }
            db.Entry(m).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}