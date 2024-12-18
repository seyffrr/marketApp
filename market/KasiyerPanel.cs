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
    public partial class KasiyerPanel : Form
    {
        public KasiyerPanel()
        {
            InitializeComponent();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btn_et_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_meyveSebze_Click(object sender, EventArgs e)
        {
            MeyveSebzePanel meyveSebzePanel = new MeyveSebzePanel();
            meyveSebzePanel.Show();
            this.Hide();
        }
    }
}
