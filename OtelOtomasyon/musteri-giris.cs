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
    public partial class musteri_giris : Form
    {
        public musteri_cikis frm3;
        public Odalar frm2;
        public musteri_giris()
        {
            InitializeComponent();
            frm2 = new Odalar();
            frm3 = new musteri_cikis();

            frm2.frm1 = this;
            frm3.frm1 = this;
        }

        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=otel.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        public OleDbDataAdapter adtr = new OleDbDataAdapter();
        public DataSet dtst = new DataSet();

        public void combo()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from bos";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox4.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox1.Sorted = true;
        }
        public void combo2()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musteri";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku[1].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox2.Sorted = true;
        }
        public void odayaz()
        {


            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musbil";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {

                switch (oku[8].ToString())
                {

                    case "A1":
                        {
                            frm2.button1.Text = oku[4].ToString();
                            frm2.button1.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A2":
                        {
                            frm2.button2.Text = oku[4].ToString();
                            frm2.button2.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A3":
                        {
                            frm2.button3.Text = oku[4].ToString();
                            frm2.button3.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A4":
                        {
                            frm2.button4.Text = oku[4].ToString();
                            frm2.button4.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A5":
                        {
                            frm2.button5.Text = oku[4].ToString();
                            frm2.button5.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B1":
                        {
                            frm2.button6.Text = oku[4].ToString();
                            frm2.button6.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B2":
                        {
                            frm2.button7.Text = oku[4].ToString();
                            frm2.button7.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B3":
                        {
                            frm2.button8.Text = oku[4].ToString();
                            frm2.button8.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B4":
                        {
                            frm2.button9.Text = oku[4].ToString();
                            frm2.button9.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B5":
                        {
                            frm2.button10.Text = oku[4].ToString();
                            frm2.button10.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C1":
                        {

                            frm2.button11.Text = oku[4].ToString();
                            frm2.button11.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C2":
                        {
                            frm2.button12.Text = oku[4].ToString();
                            frm2.button12.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C3":
                        {
                            frm2.button13.Text = oku[4].ToString();
                            frm2.button13.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C4":
                        {
                            frm2.button14.Text = oku[4].ToString();
                            frm2.button14.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C5":
                        {
                            frm2.button15.Text = oku[4].ToString();
                            frm2.button15.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D1":
                        {
                            frm2.button16.Text = oku[4].ToString();
                            frm2.button16.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D2":
                        {
                            frm2.button17.Text = oku[4].ToString();
                            frm2.button17.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D3":
                        {
                            frm2.button18.Text = oku[4].ToString();
                            frm2.button18.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D4":
                        {
                            frm2.button19.Text = oku[4].ToString();
                            frm2.button19.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D5":
                        {
                            frm2.button20.Text = oku[4].ToString();
                            frm2.button20.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                }

            }
            bag.Close();
            oku.Dispose();
        }

        private void musteri_giris_Load(object sender, EventArgs e)
        {
            combo();
            combo2();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu per = new menu();
            per.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            OleDbCommand komut = new OleDbCommand("select * from musteri where TcKimlik='" + comboBox2.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            OleDbDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                textBox1.Text = oku[1].ToString();
                textBox2.Text = oku[2].ToString();
                textBox3.Text = oku[3].ToString();
                textBox4.Text = oku[4].ToString();
              /*  textBox5.Text = oku[6].ToString();
                comboBox1.Text = oku[8].ToString();
                comboBox3.Text = oku[7].ToString();
                comboBox4.Text = oku[5].ToString();*/


            }
            bag.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "INSERT INTO musbil(TcKimlik,Ad,Soyad,CepTel,Konumu,kiraSuresi,cephe,odaturu) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox4.Text + "','" + textBox5.Text + "','"+comboBox3.Text+"','"+comboBox1.Text+"') ";
                kmt.ExecuteNonQuery();
                kmt.CommandText = "INSERT INTO dolu(doluyerler) VALUES ('" + comboBox4.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.CommandText = "DELETE from bos WHERE bosyerler='" + comboBox4.Text + "'";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();


                //satis
                bag.Open();
                OleDbCommand satis = new OleDbCommand("insert into satis(tc,giris_tarih) values('" + textBox1.Text + "','" + DateTime.Now.ToLongDateString() + "')", bag);
                satis.ExecuteNonQuery();
                bag.Close();

                comboBox1.Items.Clear();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                textBox5.Clear(); comboBox3.Text="" ;
                comboBox4.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";


                combo();
                odayaz();
                MessageBox.Show("Kayıt işlemi tamamlandı ! ");

            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }

        }
    }
}
