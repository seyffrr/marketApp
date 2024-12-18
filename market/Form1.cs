using market.controller;
using market.enumaration;
using market.model;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_girisYap_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            User result=controller.login(txt_kullaniciAdi.Text, txt_sifre.Text);
            
            if(result!=null&& result.status==LoginStatus.basarili&&result.yetki=="admin")
            {
               AdminPanel admin = new AdminPanel();
                admin.Show();
                this.Hide();
            }

            else if(result!=null&& result.status==LoginStatus.basarili && result.yetki=="kasiyer")
            {
              KasiyerPanel kasiyer = new KasiyerPanel();
                kasiyer.Show();
                this.Hide();

            }
            else if(result!= null && result.status==LoginStatus.basarisiz)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Eksik Parametre Hatası","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SifreDegistirme SD=new SifreDegistirme();
            SD.Show();
            this.Hide();
        }
    }
}
