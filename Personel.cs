using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    class Personel : People
    {

        sqlBaglantisi bgl = new sqlBaglantisi();

        public override void DuyuruOlustur()
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_PerDuyurular (PerDuyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1",duyuru);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        public override void girisyap()
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Personel Where PersonelTC=@p1 and PersonelSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tckimliknum);
            komut.Parameters.AddWithValue("@p2", sifre);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Frm_Personel_Detay fr = new Frm_Personel_Detay();
                fr.tcc = tckimliknum;
                fr.Show();
                
            }
            else
            {
                MessageBox.Show("Hatalı Tc veya Sifre Girdiniz.");
            }
            bgl.baglanti().Close();
        }

        public override void guncelle()
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Personel set PersonelAd=@p1,PersonelSoyad=@p2,PersonelSifre=@p3,PersonelCinsiyet=@p4 where PersonelTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ad);
            komut.Parameters.AddWithValue("@p2", soyad);
            komut.Parameters.AddWithValue("@p3", sifre);
            komut.Parameters.AddWithValue("@p4", cinsiyet);
            komut.Parameters.AddWithValue("@p5", tckimliknum);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }

        public override void MaasGoster()
        {
            MessageBox.Show("Bu ayki maaşınız : 2825 TL ");
        }

        public override void PersonelEkle()
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PersonelAd,PersonelSoyad,PersonelSifre,PersonelCinsiyet,PersonelTC)values (@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", ad);
            komut.Parameters.AddWithValue("@d2", soyad);
            komut.Parameters.AddWithValue("@d3", sifre);
            komut.Parameters.AddWithValue("@d4", cinsiyet);
            komut.Parameters.AddWithValue("@d5", tckimliknum);
            komut.ExecuteNonQuery();
            MessageBox.Show("Personel Oluşturuldu.");
            bgl.baglanti().Close();
        }
    }
}
