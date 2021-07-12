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
    public partial class oda_kiralama_islemleri : Form
    {
        public oda_kiralama_islemleri()
        {
            InitializeComponent();
        }
        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");

        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        DataTable dt = new DataTable();


        void doldur()
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            dt.Clear();
            OleDbDataAdapter listele = new OleDbDataAdapter("select * from satis ", baglanti);
            listele.Fill(dt);
            dataGridView1.DataSource = dt;
            listele.Dispose();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime bTarih = Convert.ToDateTime(textBox3.Text);
            DateTime kTarih = Convert.ToDateTime(textBox2.Text);
            TimeSpan Sonuc = bTarih - kTarih;
            label9.Text = Sonuc.TotalHours.ToString();
            label10.Text = Sonuc.TotalDays.ToString();
            label11.Text = Sonuc.TotalMinutes.ToString();
        }

        private void oda_kiralama_islemleri_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = (double.Parse(textBox4.Text) * double.Parse(label10.Text)).ToString();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Önce Hesaplama İşlemini Yapınız");
            }
           

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbCommand satis = new OleDbCommand("update satis set ucret='" + double.Parse(textBox5.Text) + "' where tc='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' and giris_tarih='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
            satis.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox5.Clear();
            doldur();
            MessageBox.Show("Ücretlendirme İşlemi Başarılı");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            teknik_servis tk = new teknik_servis();
            tk.Show();
            this.Hide();
        }
    }
}
