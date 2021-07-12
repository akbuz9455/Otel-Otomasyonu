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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();
        public static string musteritc = null;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum unuttum = new sifremi_unuttum();
            unuttum.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("select * from musteri where TcKimlik='" + textBox1.Text + "' and sifre ='" + textBox2.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            OleDbDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                musteritc = textBox1.Text;
                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                musteri_paneli menu = new musteri_paneli();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";
                textBox2.Text = "";
                //verileri temizler
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("select * from personel where tc='" + textBox3.Text + "' and sifre ='" + textBox4.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            OleDbDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {

                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                menu menu = new menu();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox3.Text = "";
                textBox4.Text = "";
                //verileri temizler
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OleDbCommand komut = new OleDbCommand("select * from admin where k_adi='" + textBox5.Text + "' and sifre ='" + textBox6.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            OleDbDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {

                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                teknik_servis menu = new teknik_servis();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox5.Text = "";
                textBox6.Text = "";
                //verileri temizler
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayit_ol kayit = new kayit_ol();
            kayit.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum kayit = new sifremi_unuttum();
            kayit.Show();

        }
    }
}
