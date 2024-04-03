using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MenuSistem.Models.Entities
{
    public class YeniUrunViewModel
    {
        public int Urunid { get; set; }
        public string Urunad { get; set; }
        public string UrunDetay { get; set; }
        public int UrunKategori { get; set; }
        public decimal UrunFiyat { get; set; }
        public string UrunGorsel { get; set; }
    }
}