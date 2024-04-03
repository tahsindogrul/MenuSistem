using MenuSistem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuSistem.Controllers
{
    public class UrunController : Controller
    {

        MenuDbEntities db = new MenuDbEntities();
        public ActionResult Index()
        {
            var dgr = db.TBLURUNLER.ToList();
            return View(dgr);
        }

        public ActionResult UrunGetir(int id)
        {

            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urn = db.TBLURUNLER.Find(p.Urunid);

            urn.Urunad = p.Urunad;
            urn.UrunDetay = p.UrunDetay;

            urn.UrunFiyat = p.UrunFiyat;
            urn.UrunGorsel = p.UrunGorsel;
            var ktg = db.TBLKATEGORİLER.Where(m => m.Kategoriid == p.TBLKATEGORİLER.Kategoriid).FirstOrDefault();
            urn.UrunKategori = ktg.Kategoriid;
            db.SaveChanges();
            return RedirectToAction("UrunGetir");

        }


        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler2 = (from u in db.TBLKATEGORİLER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = u.KategoriAd,
                                                  Value = u.Kategoriid.ToString()
                                              }).ToList();
            ViewBag.dgr2 = degerler2;

            return View();
        }



        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p3)
        {
            var urn = db.TBLKATEGORİLER.Where(m => m.Kategoriid == p3.TBLKATEGORİLER.Kategoriid).FirstOrDefault();
            p3.TBLKATEGORİLER = urn;
            db.TBLURUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index", "Editor");
        }






    }
}