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
    public partial class Frm_PersonelGiris : Form
    {
        public Frm_PersonelGiris()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            Personel pr = new Personel();
            pr.tckimliknum = MskTc.Text;
            pr.sifre = Txtsifre.Text;
            pr.girisyap();
        }
    }
}
