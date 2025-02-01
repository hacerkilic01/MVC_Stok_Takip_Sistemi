﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Stok_Takip_Sistemi.Models.Entity;

namespace MVC_Stok_Takip_Sistemi.Controllers
{
    public class CategoriesController : Controller
    {
        MVC_Stok_TakibiEntities1 db = new MVC_Stok_TakibiEntities1 ();
             
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
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
    }
}