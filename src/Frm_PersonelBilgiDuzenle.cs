using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class Frm_PersonelBilgiDuzenle : Form
    {
        public Frm_PersonelBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCCNo;
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs.ad = TxtAd.Text;
            prs.soyad = TxtSoyad.Text;
            prs.sifre = TxtSifre.Text;
            prs.cinsiyet = cmbCinsiyet.Text;
            prs.tckimliknum = MskTC.Text;
            prs.guncelle();
        }

        private void Frm_PersonelBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCCNo;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Personel where PersonelTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                TxtSifre.Text = dr[4].ToString();
                cmbCinsiyet.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
