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
    public partial class musteri_cikis : Form
    {
        public musteri_giris frm1;
        public musteri_cikis()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");

        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        void texteyaz()
        {
            textBox9.Text = (this.BindingContext[dtst, "musbil"].Position + 1) + " / " + this.BindingContext[dtst, "musbil"].Count;
        }

        public void combo2()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from dolu";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox1.Sorted = true;
        }
        public void listelesene()
        {
            DataView dv = new DataView();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From musbil", bag);
            adtr.Fill(dtst, "musbil");

            dv.Table = dtst.Tables[0];
            dataGrid1.DataSource = dv;
            adtr.Dispose();
            bag.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    // plakasil();
                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from musbil WHERE TcKimlik='" + textBox1.Text + "'";
                    kmt.ExecuteNonQuery();
                    kmt.CommandText = "INSERT INTO bos(bosyerler) VALUES ('" + comboBox1.Text + "') ";
                    kmt.ExecuteNonQuery();
                    kmt.CommandText = "DELETE from dolu WHERE doluyerler='" + comboBox1.Text + "'";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();

                    bag.Open();
                    OleDbCommand satis = new OleDbCommand("update satis set cikis_tarih='" + dateTimePicker1.Value.ToLongDateString() + "' where tc='" + textBox5.Text + "'", bag);
                    satis.ExecuteNonQuery();
                    bag.Close();

                    // frm1.combo();

                    dtst.Clear();



                    //


                    combo2();
                    listelesene();
                    comboBox1.Items.Clear();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position = 0;
            texteyaz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position -= 1;
            texteyaz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position += 1;
            texteyaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position = this.BindingContext[dtst, "musbil"].Count;
            texteyaz();
        }

        private void musteri_cikis_Load(object sender, EventArgs e)
        {
            combo2();
            listelesene();
            textBox1.DataBindings.Add("Text", dtst, "musbil.TcKimlik");
            textBox2.DataBindings.Add("Text", dtst, "musbil.Ad");
            textBox3.DataBindings.Add("Text", dtst, "musbil.Soyad");
            textBox4.DataBindings.Add("Text", dtst, "musbil.CepTel");
            comboBox1.DataBindings.Add("Text", dtst, "musbil.Konumu");

            textBox5.DataBindings.Add("Text", dtst, "musbil.kiraSuresi");
            comboBox3.DataBindings.Add("Text", dtst, "musbil.cephe");
            comboBox2.DataBindings.Add("Text", dtst, "musbil.odaturu");

            texteyaz();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menu per = new menu();
            per.Show();
            this.Hide();
        }
    }
}
