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
    public partial class kayit_ol : Form
    {
        public kayit_ol()
        {
            InitializeComponent();
        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox10.PasswordChar = '\0';
                textBox9.PasswordChar = '\0';
            }
            else
            {
                textBox10.PasswordChar = '*';
                textBox9.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == textBox9.Text)
            {
                OleDbCommand komut = new OleDbCommand("insert into musteri(TcKimlik,Ad,Soyad,CepTel,Sifre,Gizli_Soru,Yanit) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text  + "','" + textBox10.Text + "','" + comboBox1.Text + "','" + textBox11.Text + "')", bag);
                //
                // 
                if (bag.State == ConnectionState.Closed)
                {
                    bag.Open();
                }

                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Olma İşleminiz Başarılı");
                bag.Close();
                textBox1.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
              
                textBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();
                comboBox1.Text = "Seçiniz";
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor");
            }
        }
    }
}
