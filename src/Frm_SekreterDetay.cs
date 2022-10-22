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
    public partial class Frm_SekreterDetay : Form
    {
        public Frm_SekreterDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string TCnumara;

        private void Frm_SekreterDetay_Load(object sender, EventArgs e) 
        {
            LblTc.Text = TCnumara;

            //Ad soyad
            SqlCommand komut1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //Bransaları DataGride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *  from Tbl_Branlar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Doktorları listeye aktarma   
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd+' '+DoktorSoyad)as 'Doktorlar',DoktorBrans From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşı combobaxa aktarma 
            SqlCommand komut3 = new SqlCommand("Select BransAd From Tbl_Branlar ", bgl.baglanti());
            SqlDataReader dr2 = komut3.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", Cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevunuz Oluşturuldu");
            
           
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans= @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbdoktor.Items.Add(dr[0] +" " + dr[1]);
            }
        }

        private void BtnOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            Frm_DoktorPaneli drp = new Frm_DoktorPaneli();
            drp.Show();
        }

        private void BtnBranspaneli_Click(object sender, EventArgs e)
        {
            Frm_Brans brns = new Frm_Brans();
            brns.Show();
        }

        private void BtnRandevuList_Click(object sender, EventArgs e)
        {
            Frm_RandevuListesi rnd = new Frm_RandevuListesi();
            rnd.Show();
        }

        private void ButonGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Randevular set RandevuTarih=@r1,RandevuSaat=@r2,RandevuBrans=@r3 where HastaTC=@r4", bgl.baglanti());
            komut.Parameters.AddWithValue("@r1", MskTarih.Text);
            komut.Parameters.AddWithValue("@r2", MskSaat.Text);
            komut.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@r4", MskTC.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            Frm_Duyurular dyr = new Frm_Duyurular();
            dyr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel prs = new Personel();
            prs.duyuru = RchDuyuru.Text;
            prs.DuyuruOlustur();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelKayit pk = new PersonelKayit();
                pk.Show();
        }
    }
}
