using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tech.Entities;

namespace Tech.WebApp.ViewModels
{
    public class UrunDurumViewModel
    {
        public List<Urun> urunList { get; set; }
        public UrunBilgi urunBilgi { get; set; }

    }
    public class UrunBilgi
    {
        public int ToplamKayitSayisi { get; set; }
        public int ToplamCozulenKayitSayisi { get; set; }
        public int BugunCozulenKayitSayisi { get; set; }
        public int IslemdeOlanKayitSayisi { get; set; }
        public int GonderilenKayitSayisi { get; set; }
    }

}