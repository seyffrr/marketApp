using market.controller; // Controller sınıfını kullanmak için eklenmiş.
using market.enumaration; // Enumaration sınıfını kullanmak için eklenmiş.
using market.model; // Model sınıflarını kullanmak için eklenmiş.
using System; // Temel C# sınıflarını kullanmak için eklenmiş.
using System.Collections.Generic; // Liste gibi koleksiyonlar için gerekli.
using System.ComponentModel; // Bileşen model desteği sağlar.
using System.Data; // Veritabanı işlemleri için gerekli.
using System.Drawing; // Grafik ve görsel işleme sınıflarını içerir.
using System.Linq; // LINQ sorguları için gerekli.
using System.Text; // Metin işleme için kullanılır.
using System.Threading.Tasks; // Çoklu görev işleme desteği sağlar.
using System.Windows.Forms; // Windows Forms desteği sağlar.

namespace market // Projenin ana ad alanı.
{
    public partial class KullaniciPanel : Form // Kullanıcı panelini temsil eden sınıf.
    {
        Controller controller = new Controller(); // Controller sınıfı, iş mantığını yönetir.

        public KullaniciPanel() // Kullanıcı panelinin constructor metodu.
        {
            InitializeComponent(); // Bileşenlerin başlatılmasını sağlar.
        }

        private void groupBox1_Enter(object sender, EventArgs e) // GroupBox içine girildiğinde tetiklenir.
        {
            // Şu anda herhangi bir işlem yapılmıyor.
        }

        private void KullaniciPanel_Load(object sender, EventArgs e) // Panel yüklendiğinde çalışır.
        {
            defaultDegerleriDoldur(); // Varsayılan değerleri comboboxlara ekler.
            tumKullanciliariDoldur(); // Tüm kullanıcıları listeye yükler.
        }

        private void defaultDegerleriDoldur() // Combobox'lara varsayılan değerleri ekler.
        {
            combox_yetki.Items.Add("admin"); // Yetki olarak admin ekler.
            combox_yetki.Items.Add("kasiyer"); // Yetki olarak kasiyer ekler.
            combox_yetki.SelectedIndex = 0; // İlk seçeneği varsayılan yapar.
            //-------------------------------
            combox_bolge.Items.Add("Merkez"); // Bölge olarak Merkez ekler.
            combox_bolge.Items.Add("Gölyaka"); // Bölge olarak Gölyaka ekler.
            combox_bolge.Items.Add("Gümüşova"); // Bölge olarak Gümüşova ekler.
            combox_bolge.Items.Add("Konuralp"); // Bölge olarak Konuralp ekler.
            combox_bolge.SelectedIndex = 0; // İlk seçeneği varsayılan yapar.
            //-------------------------------
            combox_guvenlikSorusu.Items.Add("Çocukken en iyi arkadaşınızın adı?"); // Güvenlik sorusu ekler.
            combox_guvenlikSorusu.Items.Add("İlkokul sınıf öğretmeninizin adı?"); // Güvenlik sorusu ekler.
            combox_guvenlikSorusu.Items.Add("İlk Evcil Hayvanınızın Adı"); // Güvenlik sorusu ekler.
            combox_guvenlikSorusu.Items.Add("Okuduğunuz en iyi kitap?"); // Güvenlik sorusu ekler.
            combox_guvenlikSorusu.SelectedIndex = 0; // İlk seçeneği varsayılan yapar.
        }

        private void btn_cikis_Click(object sender, EventArgs e) // Çıkış butonuna tıklandığında çalışır.
        {
            Form1 form1 = new Form1(); // Giriş ekranını açar.
            form1.Show(); // Giriş ekranını gösterir.
            this.Hide(); // Mevcut formu gizler.
        }

        private void tumKullanciliariDoldur() // Tüm kullanıcıları listeye yükler.
        {
            List<User> userList = controller.tumKullanicilariGetir(); // Controller'dan kullanıcı listesini alır.
            dataGridView1.DataSource = userList; // Verileri DataGridView'e yükler.
        }

        private void btn_kayitEkle_Click(object sender, EventArgs e) // Yeni kayıt eklemek için çalışır.
        {
            User user = new User(); // Yeni bir kullanıcı nesnesi oluşturur.
            user.kullaniciAdi = txt_kullaniciAdi.Text; // Kullanıcı adını alır.
            user.sifre = txt_sifre.Text; // Şifreyi alır.
            user.yetki = combox_yetki.SelectedItem.ToString(); // Yetkiyi alır.
            user.bolge = combox_bolge.SelectedItem.ToString(); // Bölgeyi alır.
            user.emailAdres = txt_emailAdres.Text; // E-posta adresini alır.
            user.guvenlikSorusu = combox_guvenlikSorusu.SelectedItem.ToString(); // Güvenlik sorusunu alır.
            user.guvenlikCevabi = txt_guvenlikCevabi.Text; // Güvenlik cevabını alır.

            LoginStatus sonuc = controller.kullaniciEkle(user); // Kullanıcıyı ekleme işlemini yapar.
            if (sonuc == LoginStatus.basarili) // İşlem başarılıysa.
            {
                MessageBox.Show("Kayıt başarıyla eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı gösterir.
                dataGridView1.DataSource = controller.tumKullanicilariGetir(); // Güncel listeyi getirir.
            }
            else // İşlem başarısızsa.
            {
                MessageBox.Show("Gerekli alanların tamamamını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Uyarı mesajı gösterir.
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) // Tabloya çift tıklandığında çalışır.
        {
            txt_kullaniciAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString(); // Seçili satırdan kullanıcı adını alır.
            txt_sifre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); // Şifreyi alır.
            combox_yetki.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); // Yetkiyi alır.
            combox_bolge.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); // Bölgeyi alır.
            txt_emailAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString(); // E-posta adresini alır.
            combox_guvenlikSorusu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString(); // Güvenlik sorusunu alır.
            txt_guvenlikCevabi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); // Güvenlik cevabını alır.
        }

        private void btn_kayitGuncelle_Click(object sender, EventArgs e) // Mevcut kaydı güncellemek için çalışır.
        {
            User user = new User(); // Yeni bir kullanıcı nesnesi oluşturur.
            user.id = int.Parse(txt_id.Text); // Kullanıcı ID'sini alır.
            user.kullaniciAdi = txt_kullaniciAdi.Text; // Kullanıcı adını alır.
            user.sifre = txt_sifre.Text; // Şifreyi alır.
            user.yetki = combox_yetki.SelectedItem.ToString(); // Yetkiyi alır.
            user.bolge = combox_bolge.SelectedItem.ToString(); // Bölgeyi alır.
            user.emailAdres = txt_emailAdres.Text; // E-posta adresini alır.
            user.guvenlikSorusu = combox_guvenlikSorusu.SelectedItem.ToString(); // Güvenlik sorusunu alır.
            user.guvenlikCevabi = txt_guvenlikCevabi.Text; // Güvenlik cevabını alır.

            LoginStatus sonuc = controller.kullaniciGuncelle(user); // Güncelleme işlemini yapar.

            if (sonuc == LoginStatus.basarili) // İşlem başarılıysa.
            {
                MessageBox.Show("Kayıt başarıyla Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı gösterir.
                dataGridView1.DataSource = controller.tumKullanicilariGetir(); // Güncel listeyi getirir.
            }
            else // İşlem başarısızsa.
            {
                MessageBox.Show("Kayıt güncellenirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı gösterir.
            }
        }

        private void btn_kayitSil_Click(object sender, EventArgs e) // Seçili kaydı silmek için çalışır.
        {
            if (!string.IsNullOrEmpty(txt_id.Text)) // ID boş değilse.
            {
                LoginStatus sonuc = controller.kullaniciSil(int.Parse(txt_id.Text)); // Silme işlemini yapar.

                if (sonuc == LoginStatus.basarili) // İşlem başarılıysa.
                {
                    MessageBox.Show("Kayıt başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); // Başarı mesajı gösterir.
                    dataGridView1.DataSource = controller.tumKullanicilariGetir(); // Güncel listeyi getirir.
                }
                else if (sonuc == LoginStatus.basarisiz) // İşlem başarısızsa.
                {
                    MessageBox.Show("Kayıt silinirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); // Hata mesajı gösterir.
                }
                else // ID bulunamazsa.
                {
                    MessageBox.Show("Silmek istediğiniz kaydın id değerini giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Uyarı mesajı gösterir.
                }
            }
            else // ID boşsa.
            {
                MessageBox.Show("Silmek istediğiniz kaydın id değerini giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Uyarı mesajı gösterir.
            }
        }

        private void btn_geri_Click(object sender, EventArgs e) // Geri butonuna tıklandığında çalışır.
        {
            AdminPanel admin = new AdminPanel(); // Yönetici panelini açar.
            admin.Show(); // Yönetici panelini gösterir.
            this.Hide(); // Mevcut formu gizler.
        }
    }
}