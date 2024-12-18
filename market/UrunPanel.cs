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
    public partial class UrunPanel : Form

    {
        controller.Controller controller = new controller.Controller();
        public UrunPanel()
        {
            InitializeComponent();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            AdminPanel admin = new AdminPanel(); // Yönetici panelini açar.
            admin.Show(); // Yönetici panelini gösterir.
            this.Hide(); // Mevcut formu gizler.
        }

        private void UrunPanel_Load(object sender, EventArgs e)
        {
            defaultAlanlarıDoldur();
            tumUrunleriGetir();

        }
        public void defaultAlanlarıDoldur()
        {
            combox_urunIsim.Items.Add("Brokoli");
            combox_urunIsim.Items.Add("Çilek");
            combox_urunIsim.Items.Add("Elma");
            combox_urunIsim.Items.Add("Lahana");
            combox_urunIsim.Items.Add("Muz");
            combox_urunIsim.Items.Add("Portakal");
            combox_urunIsim.Items.Add("Üzüm");

        }

        public void tumUrunleriGetir()
        {
            dataGridView1.DataSource = controller.tumUrunleriGetir();
        }

        private void btn_kayitEkle_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.id = txt_id.Text; 
            urun.qrkod = txt_qrkod.Text;
            urun.barkodKod = txt_barkodKod.Text;
            urun.olusturmaTarih = datetime_olusturmaTarih.Value;
            urun.guncellemeTarih=datetime_guncellemeTarih.Value;
            urun.urunIsim=combox_urunIsim.SelectedItem.ToString();
            urun.kilo=int.Parse(txt_kilo.Text);
            urun.fiyat=int.Parse(txt_fiyat.Text);   
            urun.ciro=int.Parse(txt_ciro.Text);

            LoginStatus sonuc = controller.urunEkle(urun);
            if (sonuc == LoginStatus.basarili) 
            {
                MessageBox.Show("Ürün başarıyla eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı gösterir.
                dataGridView1.DataSource = controller.tumUrunleriGetir(); 
            }
            else if(sonuc==LoginStatus.basarisiz) // İşlem başarısızsa.
            {
                MessageBox.Show("Ürün Eklenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // hata mesajı gösterir.
            }
            else
            {
                MessageBox.Show("Gerekli alanların tamamamını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Uyarı mesajı gösterir.
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_qrkod.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_barkodKod.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            datetime_olusturmaTarih.Value =DateTime.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            if (!string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells[4].Value.ToString()))
            {
                datetime_guncellemeTarih.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            }
            combox_urunIsim.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_kilo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_fiyat.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txt_ciro.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void btn_kayitGuncelle_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.id=txt_id.Text;
            urun.qrkod=txt_qrkod.Text;
            urun.barkodKod=txt_barkodKod.Text;
            urun.olusturmaTarih=datetime_olusturmaTarih.Value;
            urun.guncellemeTarih = datetime_guncellemeTarih.Value;
            urun.urunIsim=combox_urunIsim.SelectedItem.ToString();
            urun.fiyat=int.Parse(txt_fiyat.Text);
            urun.kilo = int.Parse(txt_kilo.Text);
            urun.ciro=int.Parse(txt_ciro.Text);


            LoginStatus sonuc = controller.urunGuncelle(urun);
            if (sonuc == LoginStatus.basarili)
            {
                MessageBox.Show("Ürün başarıyla güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı gösterir.
                dataGridView1.DataSource = controller.tumUrunleriGetir();
            }
            else if (sonuc == LoginStatus.basarisiz) // İşlem başarısızsa.
            {
                MessageBox.Show("Ürün Güncellenemdi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // hata mesajı gösterir.
            }
            else
            {
                MessageBox.Show("Gerekli alanların tamamamını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Uyarı mesajı gösterir.
            }

           
        }

        private void btn_kayitSil_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_id.Text))
            {
                LoginStatus sonuc= controller.urunSil(txt_id.Text);
                if(sonuc == LoginStatus.basarili)
                {
                    MessageBox.Show("Kayıt Başarıyla Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = controller.tumUrunleriGetir();
                }
                else
                {
                    MessageBox.Show("Silmek İstediğiniz Ürünün İd değerini giriniz!", "Eksik Parametre", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Silmek İstediğiniz Ürünün İd değerini giriniz!","Uyarı", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
