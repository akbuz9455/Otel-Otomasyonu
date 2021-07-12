using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OtelOtomasyon
{
    public partial class cari_istatistikler : Form
    {
        public cari_istatistikler()
        {
            InitializeComponent();
        }
        public OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click_1(object sender, EventArgs e)
        {

            OleDbCommand kmt;
            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }

            kmt = new OleDbCommand("Select count(TcKimlik) as tc From musteri", baglan);
            OleDbDataReader dr = kmt.ExecuteReader();

            if (dr.Read())
            {
                label42.Text = dr.GetValue(0).ToString() + " Müşteri Sayısına Sahibiz.";

            }
            baglan.Close();



            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }

            kmt = new OleDbCommand("Select sum(ucret) as ucret From satis", baglan);
            OleDbDataReader dr2 = kmt.ExecuteReader();

            if (dr2.Read())
            {
                label43.Text = dr2.GetValue(0).ToString() + " TL Toplam Kazanılan Ücret";

            }
            baglan.Close();




            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }

            kmt = new OleDbCommand("select AVG(ucret) from satis ", baglan);
            OleDbDataReader dr3 = kmt.ExecuteReader();

            if (dr3.Read())
            {
                label44.Text = dr3.GetValue(0).ToString() + "TL Ortalama Oda Başı Kazanılan Ücret.";

            }
            baglan.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            teknik_servis tk = new teknik_servis();
            tk.Show();
            this.Hide();
        }
    }
}
