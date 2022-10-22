using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class PersonelKayit : Form
    {
        public PersonelKayit()
        {
            InitializeComponent();
        }

        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs.ad = TxtAd.Text;
            prs.soyad = TxtSoyad.Text;
            prs.sifre = TxtSifre.Text;
            prs.cinsiyet = CmbCinsiyet.Text;
            prs.tckimliknum = MskTC.Text;
            prs.PersonelEkle();
        }
    }
}
