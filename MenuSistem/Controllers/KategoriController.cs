using MenuSistem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuSistem.Controllers
{
    public class KategoriController : Controller
    {

        MenuDbEntities db = new MenuDbEntities();



        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİLER.ToList();
            return View(degerler);
        }


        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(TBLKATEGORİLER p)
        {
            var ktg = db.TBLKATEGORİLER.Find(p.Kategoriid);
            ktg.KategoriAd = p.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index", "Editor");

        }


        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİLER p2)
        {
            db.TBLKATEGORİLER.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Index", "Editor");
        }


    }
}