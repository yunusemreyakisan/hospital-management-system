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
    public partial class Frm_Duyurular : Form
    {
        public Frm_Duyurular()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();


        private void Frm_Duyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Duyurular",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
