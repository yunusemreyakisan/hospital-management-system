using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    interface Ifun1
    {
        void ekle();
        void sil();
        void güncelle();

    }
    public class fun : Frm_DoktorPaneli,Ifun1 
    {
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string ad;
        public string soyad;
        public string Brans;
        public string tcno;
        public string sifre;
        public void ekle()
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre)values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", ad);
            komut.Parameters.AddWithValue("@d2", soyad);
            komut.Parameters.AddWithValue("@d3", Brans);
            komut.Parameters.AddWithValue("@d4", tcno);
            komut.Parameters.AddWithValue("@d5", sifre);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        public void güncelle()
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4", bgl.baglanti());
            komut1.Parameters.AddWithValue("@d1", ad);
            komut1.Parameters.AddWithValue("@d2", soyad);
            komut1.Parameters.AddWithValue("@d3", Brans);
            komut1.Parameters.AddWithValue("@d4", tcno);
            komut1.Parameters.AddWithValue("@d5", sifre);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            
        }

        public void sil()
        {
            SqlCommand komut = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",tcno);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}
