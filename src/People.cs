using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje_Hastane
{
    abstract class People
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tckimliknum { get; set; }
        public string sifre { get; set; }
        public string cinsiyet { get; set; }
        public string  Maas { get; set; }
        public string duyuru { get; set; }

        public abstract void girisyap();
        public abstract void guncelle();
        public abstract void MaasGoster();
        public abstract void DuyuruOlustur();
        public abstract void PersonelEkle();

    }
}
