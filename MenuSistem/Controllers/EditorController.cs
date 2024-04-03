using MenuSistem.Models;
using MenuSistem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MenuSistem.Controllers
{
    public class EditorController : Controller
    {
        MenuDbEntities db = new MenuDbEntities();
        public ActionResult Index()
        {
            var viewModel = new KategoriUrunViewModel
            {
                Kategoriler = db.TBLKATEGORİLER.ToList(),
            };



            return View(viewModel);
        }

       



        public ActionResult Sil(int id)
        {
            var kategori= db.TBLKATEGORİLER.Find(id);
            if (kategori == null)
            {
                return HttpNotFound("Kategori Değeri Bulunamadı!");
            }

            db.TBLKATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}