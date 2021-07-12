using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyon
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            musteri_islemleri gecis = new musteri_islemleri();
            gecis.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri_giris gecis = new musteri_giris();
            gecis.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Odalar gecis = new Odalar();
            gecis.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_cikis gecis = new musteri_cikis();
            gecis.Show();
            this.Hide();
        }
    }
}
