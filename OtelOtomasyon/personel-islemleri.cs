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
    public partial class personel_islemleri : Form
    {
        public personel_islemleri()
        {
            InitializeComponent();
        }

        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        DataTable dt = new DataTable();

        private void button5_Click(object sender, EventArgs e)
        {
            teknik_servis ts = new teknik_servis();
            ts.Show();
            this.Hide();
        }

        void doldur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from personel ", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[1].Width = 80;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 77;
                dataGridView1.Columns[4].Width = 76;
                dataGridView1.Columns[5].Width = 76;
                dataGridView1.Columns[6].Width = 80;
                baglanti.Close();
                maskedTextBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text.Length != 11)
            {
                MessageBox.Show("hata!!! TC numarası giriş Formatınız Yanlıştır.");
            }
            else
            {

                try
                {
                    OleDbCommand komut = new OleDbCommand("insert into personel(tc,adi_soyadi,cinsiyet,telefon,dogum_tarihi,gorevi,sifre,gizli_soru,yaniti) values('" + maskedTextBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "')", baglanti);
                    //
                    // 
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Ekleme İşleminiz Başarılı");
                    baglanti.Close();

                    doldur();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }
            }
        }

        private void personel_islemleri_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() != "")
            {
                try
                {

                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    OleDbCommand sil = new OleDbCommand("delete from personel where tc='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti);
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Silme İşleminiz Başarılı");
                    doldur();
                    baglanti.Close();

                }
                catch
                {

                    ;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand adtr = new OleDbCommand("UPDATE personel set tc='" + maskedTextBox1.Text + "',adi_soyadi='" + textBox2.Text + "',cinsiyet='" + textBox3.Text + "',telefon='" + textBox4.Text + "',dogum_tarihi='" + textBox5.Text + "',gorevi='" + textBox6.Text + "'where tc='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti);
            adtr.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            doldur();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {


            dt.Clear();

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From personel where tc like'%" + textBox7.Text + "%'or adi_soyadi like '%" + textBox7.Text + "%'or cinsiyet like '%" + textBox7.Text + "%'or telefon like '%" + textBox7.Text + "%'or dogum_tarihi like '%" + textBox7.Text + "%'", baglanti);
            adtr.Fill(dt);
            dataGridView1.DataSource = dt;
            adtr.Dispose();


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 77;
            dataGridView1.Columns[4].Width = 76;
            dataGridView1.Columns[5].Width = 76;
            dataGridView1.Columns[6].Width = 80;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }
    }
}
