using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class ProductsController : Controller
    {
        MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1();
        public ActionResult Index()
        {
            var model = db.Products.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Product();
            Reload(model);
            return View(model);

        }

        private void Reload(Product model)
        {
            List<Category> categorylist = db.Categories.OrderBy(x => x.CategoryName).ToList();
            model.CategoryList = (from x in categorylist
                                  select new SelectListItem
                                  {
                                      Text = x.CategoryName,
                                      Value = x.ID.ToString()
                                  }
            ).ToList();

            List<Unit> unitlist = db.Units.OrderBy(x => x.Unit1).ToList();
            model.UnitList = (from x in unitlist
                              select new SelectListItem
                              {
                                  Text = x.Unit1,
                                  Value = x.ID.ToString()
                              }
                              ).ToList();
            model.BrandList.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
        }

        [HttpPost]
        public ActionResult Add(Product p)
        {
            return RedirectToAction("Index");
        }
        public JsonResult GetBrand(int id2)
        {
            var model = new Product();
            List<Brand> brandlist = db.Brands.Where(x => x.CategoryID == id2).OrderBy(x => x.Brand1).ToList();
            model.BrandList = (from x in brandlist
                               select new SelectListItem
                               {
                                   Text = x.Brand1,
                                   Value = x.ID.ToString()
                               }).ToList();
            model.BrandList.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            return Json(model.BrandList, JsonRequestBehavior.AllowGet);
        }
    }
}