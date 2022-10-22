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
    public partial class Frm_DoktorPaneli : Form
    {
        public Frm_DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void Frm_DoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Branşı combobaxa aktarma 
            SqlCommand komut3 = new SqlCommand("Select BransAd From Tbl_Branlar ", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            fun f1 = new fun();
            f1.ad = TxtAd.Text;
            f1.soyad = TxtSoyad.Text;
            f1.Brans = CmbBrans.Text;
            f1.tcno = MskTc.Text;
            f1.sifre = TxtSifre.Text;
            f1.ekle();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            fun f2 = new fun();
            f2.ad = TxtAd.Text;
            f2.soyad = TxtSoyad.Text;
            f2.Brans = CmbBrans.Text;
            f2.tcno = MskTc.Text;
            f2.sifre = TxtSifre.Text;
            f2.sil();
            MessageBox.Show("Kayıt Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            fun f3 = new fun();
            f3.ad = TxtAd.Text;
            f3.soyad = TxtSoyad.Text;
            f3.Brans = CmbBrans.Text;
            f3.tcno = MskTc.Text;
            f3.sifre = TxtSifre.Text;
            f3.güncelle();
            MessageBox.Show("Doktor Guncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
