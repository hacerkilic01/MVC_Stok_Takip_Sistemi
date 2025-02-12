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
        public  MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1();
        public LinkedList<Brand> BrandLinkedList = new LinkedList<Brand>();
        public ActionResult Index()
        {
            var BrandFromdb = db.Brands.ToList();
            foreach (var brand in BrandFromdb) 
            { 
                BrandLinkedList.AddLast(brand); 
            }
         
            return View(BrandLinkedList.ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            SelectUpdateInformation();
            return View();
        }

        private void SelectUpdateInformation()
        {
            var model = new Brand();
            List<SelectListItem> list = new List<SelectListItem>(
                from x in db.Categories
                select new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.CategoryName
                }
                ).ToList();
            ViewBag.l = list;
        }

        [HttpPost]
        public ActionResult Add(Brand m)
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

       
       
        public ActionResult UpdateInformation(int id)
        {
            SelectUpdateInformation();
            var find = db.Brands.Find(id);
            return View(find);
        }
        [HttpPost]
        public ActionResult Update(Brand p)
        {
            if (!ModelState.IsValid)
            {
                SelectUpdateInformation();
                return View("UpdateInformation");
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void UpdateBrand(Brand updatedBrand)
        {
            var node = BrandLinkedList.First;
            while (node != null)
            {
                if (node.Value.ID == updatedBrand.ID)
                {
                    node.Value = updatedBrand;
                }
                node = node.Next;
            }
        }
        public ActionResult DeleteBrand(Brand p)
        {
            var getir = db.Brands.Find(p.ID);
            return View(getir);
        }

        public ActionResult Delete(Brand p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}