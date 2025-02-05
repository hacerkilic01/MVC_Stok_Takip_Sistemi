using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class CategoriesController : Controller
    {
        public MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1 ();
        //public  CategoryLinkedList CategoryList = new CategoryLinkedList ();
        public LinkedList<Category> CategoryLinkedList = new LinkedList<Category>();


        public ActionResult Index()
        {
            var CategoriesFromDb = db.Categories.ToList ();
            foreach (var category in CategoriesFromDb)
            {
                CategoryLinkedList.AddLast(category);
            }
            return View(CategoryLinkedList.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add2(Category p)
        {
            db.Categories.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateInformation(Category p)
        {
            var model = db.Categories.Find(p.ID);
            if(model== null) return HttpNotFound(); //ID değeri uyuşmuyorsa yönlendirsin
            return View(model);
        }
        //public ActionResult Update(Category p)
        //{
        //    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();
        //    CategoryList.Update(p);
        //    return RedirectToAction("Index");
        //}
        public void UpdateCategory(Category updatedCategory)
        {
            var node = CategoryLinkedList.First; // İlk düğümden başla
            while (node != null)
            {
                if (node.Value.ID == updatedCategory.ID) // ID eşleşirse güncelle
                {
                    node.Value = updatedCategory;
                    //break;
                }
                node = node.Next; // Sonraki düğüme geç
            }
        }

    }
}