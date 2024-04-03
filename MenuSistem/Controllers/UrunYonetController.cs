using MenuSistem.Models;
using MenuSistem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MenuSistem.Controllers
{
    public class UrunYonetController : Controller
    {
        MenuDbEntities db = new MenuDbEntities();

  
        public ActionResult Index(int id)
        {    
         

            var kategori = db.TBLKATEGORİLER.Find(id);

           
            var urunler = db.TBLURUNLER.Where(u => u.UrunKategori == id).ToList();
           

            // Kategori ve ürünleri içeren bir ViewModel oluşturdum
            var viewModel = new KategoriUrunViewModel
            {
                SecilenKategori = kategori,
                Urunler = urunler
            };

          
            ViewBag.KategoriAd = kategori.KategoriAd;

         
            return View("Index", viewModel);

        }

        [HttpGet]
        public ActionResult UrunSil(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            if (urn == null)
            {
                return HttpNotFound("Aranan Ürün Bulunamadı!");
            }
          
            db.TBLURUNLER.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index","Editor");
        }

    




      

    }
}