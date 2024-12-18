using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btn_kullanici_Click(object sender, EventArgs e)
        {
            KullaniciPanel kullaniciPanel = new KullaniciPanel();
            kullaniciPanel.Show();
            this.Hide();

        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btn_urunler_Click(object sender, EventArgs e)
        {
            UrunPanel urun = new UrunPanel();   
            urun.Show();
            this.Hide();

        }
    }
}
