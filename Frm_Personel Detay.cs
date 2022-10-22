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
    public partial class Frm_Personel_Detay : Form
    {
        public Frm_Personel_Detay()
        {
            InitializeComponent();
        }
        public string tcc;
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void Frm_Personel_Detay_Load(object sender, EventArgs e)
        {
            lblTc.Text = tcc;
            SqlCommand komut = new SqlCommand("Select PersonelAd , PersonelSoyad From Tbl_Personel where PersonelTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            //Duyuru çekme 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_PerDuyurular ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Çalışma saatlerini çekme
            /* DataTable dt1 = new DataTable();
             SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_PerCalismaSaatleri ", bgl.baglanti());
             da1.Fill(dt1);
             dataGridView2.DataSource = dt1;*/

            dataGridView2.Rows[0].Cells[0].Value = "09:00-17:00";
            dataGridView2.Rows[0].Cells[1].Value = "09:00-17:00";
            dataGridView2.Rows[0].Cells[2].Value = "09:00-17:00";
            dataGridView2.Rows[0].Cells[3].Value = "09:00-17:00";
            dataGridView2.Rows[0].Cells[4].Value = "09:00-17:00";
        }

        private void btnbilgiduzenle_Click(object sender, EventArgs e)
        {
            Frm_PersonelBilgiDuzenle fr = new Frm_PersonelBilgiDuzenle();
            fr.TCCNo = lblTc.Text;
            fr.Show();
        }

        private void btnMaasgoruntule_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs.MaasGoster();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
