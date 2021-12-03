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

namespace PersonelKayit
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DG2OBOI;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select * from tbl_yonetici where kullaniciad=@k1 and sifre=@k2",baglanti);
            komut1.Parameters.AddWithValue("@k1", txtKullanici.Text);
            komut1.Parameters.AddWithValue("@k2", txtSifre.Text);

            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                Frmanaforms frm = new Frmanaforms();
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı ya da şifre!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            baglanti.Close();


        }
    }
}
