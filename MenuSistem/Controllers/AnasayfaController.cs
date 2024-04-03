using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuSistem.Models;
using MenuSistem.Models.Entities;

namespace MenuSistem.Controllers
{
    public class AnasayfaController : Controller
    {
        
        MenuDbEntities db = new MenuDbEntities();
      
        public ActionResult Index()
        {
            var viewModel = new KategoriUrunViewModel
            {
                Kategoriler = db.TBLKATEGORİLER.ToList(),
                Urunler = db.TBLURUNLER.ToList()
            };

            return View(viewModel);
        }
    }
}