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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DG2OBOI;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select count(*) from tbl_personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //evli sayisi

            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select count(*) from tbl_personel where perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblToplamEvli.Text = dr2[0].ToString();
            }

            baglanti.Close();


            //bekar sayisi

            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_personel where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblToplamBekar.Text = dr3[0].ToString();
            }

            baglanti.Close();


            //farklı sehir sayisi

            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) from tbl_personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblFarkliSehir.Text = dr4[0].ToString();
            }

            baglanti.Close();


            //toplam maas

            baglanti.Open();

            SqlCommand komut5 = new SqlCommand("select sum(permaas) from tbl_personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text = dr5[0].ToString() + " TL";
            }

            baglanti.Close();



            //ort maas

            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select avg(permaas) from tbl_personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text = dr6[0].ToString() + " TL";
            }

            baglanti.Close();
        }
    }
}
