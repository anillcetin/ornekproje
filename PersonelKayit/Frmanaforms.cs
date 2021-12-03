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
    public partial class Frmanaforms : Form
    {
        public Frmanaforms()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DG2OBOI;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            txtPerId.Text = "";
            txtPerAd.Text = "";
            txtPerSoyad.Text = "";
            txtMeslek.Text = "";
            comboBox1.Text = "";
            mskMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtPerAd.Focus();

        }

 

        private void btnListele_Click(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into tbl_Personel (perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",txtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", txtPerSoyad.Text);
            komut.Parameters.AddWithValue("@p3",comboBox1.Text);
            komut.Parameters.AddWithValue("@p4",mskMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Personel eklendi...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "True";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "False";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtPerId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtPerAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPerSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text =dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
            else if(label8.Text == "False")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutsil = new SqlCommand("delete from tbl_personel where perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtPerId.Text);
            komutsil.ExecuteNonQuery();          

            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutguncelle = new SqlCommand("update tbl_personel set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtPerAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtPerSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mskMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtPerId.Text); 



            komutguncelle.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Personel güncellendi...");
        }

        private void btnİsta_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Frmgrafikler frg = new Frmgrafikler();
            frg.Show();
        }
    }
}
