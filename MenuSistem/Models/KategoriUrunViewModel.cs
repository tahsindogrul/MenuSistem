using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuSistem.Models.Entities;

namespace MenuSistem.Models
{
    public class KategoriUrunViewModel
    {
        public TBLKATEGORİLER SecilenKategori { get; set; }
        public TBLURUNLER SecilenUrun { get; set; }
        public List<TBLKATEGORİLER> Kategoriler { get; set; }
        public List<TBLURUNLER> Urunler { get; set; }
    }
}