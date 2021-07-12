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
    public partial class musteri_paneli : Form
    {
        public musteri_paneli()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();

        public void listelesene()
        {
            DataView dv = new DataView();
            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From musteri", bag);
            adtr.Fill(dtst, "musteri");

            dv.Table = dtst.Tables[0];

            adtr.Dispose();
            bag.Close();
        }

        private void musteri_paneli_Load(object sender, EventArgs e)
        {
            listelesene();
            textBox1.DataBindings.Add("Text", dtst, "musteri.TcKimlik");
            textBox2.DataBindings.Add("Text", dtst, "musteri.Ad");
            textBox3.DataBindings.Add("Text", dtst, "musteri.Soyad");
            textBox4.DataBindings.Add("Text", dtst, "musteri.CepTel");
         
            textBox9.DataBindings.Add("Text", dtst, "musteri.Sifre");
            textBox10.DataBindings.Add("Text", dtst, "musteri.Sifre");
            comboBox1.DataBindings.Add("Text", dtst, "musteri.Gizli_Soru");
            textBox11.DataBindings.Add("Text", dtst, "musteri.Yanit");
        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand guncelle = new OleDbCommand("update musteri set TcKimlik='" + textBox1.Text + "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',CepTel='" + textBox4.Text  + "',Sifre='" + textBox9.Text + "',Gizli_Soru='" + comboBox1.Text + "',Yanit='" + textBox11.Text + "' where TcKimlik='" + Form1.musteritc + "'", bag);
            bag.Open();
            guncelle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            OleDbCommand komut = new OleDbCommand("select * from musbil where TcKimlik='" + textBox1.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            OleDbDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                MessageBox.Show("Odanızın Oteldeki Konumu " + oku[5].ToString());// uyari verir
                bag.Close();//bağlantıyı kapar

            }
            else
            {
                MessageBox.Show("Odanız Otelde Bulunmamaktadır");//uyari verir
                bag.Close();//bağlantıyı kapar

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
