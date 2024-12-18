using AForge.Video.DirectShow; // Kameradan video akışı almak için gerekli kütüphane.
using market.model; // Projenin model sınıflarını kullanmak için gerekli.
using System; // Temel C# sınıfları için gerekli.
using System.Collections.Generic; // Koleksiyonlar için gerekli.
using System.ComponentModel; // Bileşen modeli işlemleri için gerekli.
using System.Data; // Veritabanı işlemleri için gerekli.
using System.Drawing; // Grafik ve görsel işlemler için gerekli.
using System.Linq; // LINQ sorguları için gerekli.
using System.Media; // Ses işlemleri için gerekli.
using System.Text; // Metin işleme için gerekli.
using System.Threading.Tasks; // Çoklu görev işlemleri için gerekli.
using System.Windows.Forms; // Windows Forms desteği için gerekli.
using ZXing; // Barkod okuma işlemleri için gerekli kütüphane.

namespace market
{
    public partial class MeyveSebzePanel : Form // Meyve ve sebze panelini temsil eden form sınıfı.
    {
        int sayi1; // İlk sayıyı saklamak için değişken.
        int sayi2; // İkinci sayıyı saklamak için değişken.
        int islemTip; // Yapılacak işlemi temsil eden değişken (1: Toplama, 2: Çıkarma, vb.).

        FilterInfoCollection fic; // Kameraları listelemek için değişken.
        VideoCaptureDevice vcd; // Seçilen kamerayı temsil eden değişken.

        public MeyveSebzePanel() // Constructor metodu.
        {
            InitializeComponent(); // Bileşenlerin başlatılmasını sağlar.
            txt_islem.Text = "0"; // İşlem metin kutusunu varsayılan değere ayarlar.
        }

        private void button8_Click(object sender, EventArgs e) // Boş buton tıklama işlemi (işlevsellik eklenmemiş).
        {
        }

        private void MeyveSebzePanel_Load(object sender, EventArgs e) // Form yüklendiğinde çalışır.
        {
            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice); // Tüm video giriş cihazlarını alır.
            foreach (FilterInfo camera in fic) // Kameraları döngüyle ekler.
            {
                cmb_kameraAc.Items.Add(camera.Name); // Kameraların isimlerini combobox'a ekler.
            }
        }

        private void secilenTus(object sender, EventArgs e) // Bir tuşa tıklanıldığında çalışır.
        {
            if (txt_islem.Text == "0") // Eğer işlem alanında sadece "0" varsa.
            {
                txt_islem.Text = ""; // Temizle.
            }
            txt_islem.Text += ((Button)sender).Text; // Tıklanan tuşun değerini ekle.
        }

        private void btn_temizle_Click(object sender, EventArgs e) // Temizle butonuna tıklandığında çalışır.
        {
            txt_islem.Text = "0"; // İşlem metin kutusunu sıfırla.
        }

        private void btn_topla_Click(object sender, EventArgs e) // Toplama işlemi için çalışır.
        {
            islemTip = 1; // İşlem tipi toplama olarak ayarlanır.
            sayi1 = int.Parse(txt_islem.Text); // İlk sayı alınır.
            txt_islem.Text = "0"; // İşlem kutusu sıfırlanır.
        }

        private void btn_esittir_Click(object sender, EventArgs e) // Eşittir butonuna tıklandığında çalışır.
        {
            if (islemTip == 1) // Toplama işlemi.
            {
                sayi2 = int.Parse(txt_islem.Text); // İkinci sayı alınır.
                txt_islem.Text = (sayi1 + sayi2).ToString(); // Sonuç hesaplanır ve gösterilir.
            }
            else if (islemTip == 2) // Çıkarma işlemi.
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 - sayi2).ToString();
            }
            else if (islemTip == 3) // Çarpma işlemi.
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 * sayi2).ToString();
            }
            else if (islemTip == 4) // Bölme işlemi.
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 / sayi2).ToString();
            }
        }

        private void btn_cikar_Click(object sender, EventArgs e) // Çıkarma işlemi için çalışır.
        {
            islemTip = 2; // İşlem tipi çıkarma olarak ayarlanır.
            sayi1 = int.Parse(txt_islem.Text); // İlk sayı alınır.
            txt_islem.Text = "0"; // İşlem kutusu sıfırlanır.
        }

        private void btn_carp_Click(object sender, EventArgs e) // Çarpma işlemi için çalışır.
        {
            islemTip = 3; // İşlem tipi çarpma olarak ayarlanır.
            sayi1 = int.Parse(txt_islem.Text); // İlk sayı alınır.
            txt_islem.Text = "0"; // İşlem kutusu sıfırlanır.
        }

        private void btn_bol_Click(object sender, EventArgs e) // Bölme işlemi için çalışır.
        {
            islemTip = 4; // İşlem tipi bölme olarak ayarlanır.
            sayi1 = int.Parse(txt_islem.Text); // İlk sayı alınır.
            txt_islem.Text = "0"; // İşlem kutusu sıfırlanır.
        }

        private void btn_geriGel_Click(object sender, EventArgs e) // Geri silme işlemi için çalışır.
        {
            if (txt_islem.Text.Length != 0) // Eğer işlem kutusu boş değilse.
            {
                txt_islem.Text = txt_islem.Text.Substring(0, txt_islem.Text.Length - 1); // Son karakteri sil.
            }
            else
            {
                txt_islem.Text = "0"; // Kutuyu sıfırla.
            }
        }

        private void btn_kameraAc_Click(object sender, EventArgs e) // Kamera açma işlemi için çalışır.
        {
            vcd = new VideoCaptureDevice(fic[cmb_kameraAc.SelectedIndex].MonikerString); // Seçilen kamerayı başlatır.
            vcd.NewFrame += Vcd_NewFrame; // Yeni bir kare alındığında çalışacak metot.
            vcd.Start(); // Kamerayı başlatır.
            timer1.Start(); // Zamanlayıcıyı başlatır.
        }

        private void Vcd_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs) // Yeni kare alındığında çalışır.
        {
            pctbox_kamera.Image = (Bitmap)eventArgs.Frame.Clone(); // Alınan kareyi görüntü kutusuna ekler.
        }

        private void button1_Click(object sender, EventArgs e) // Kamerayı durdurma işlemi için çalışır.
        {
            vcd.Stop(); // Kamerayı durdurur.
            pctbox_kamera.Image = Image.FromFile("C:\\Users\\MONSTER\\Desktop\\Dersler\\market otomasyyon\\resimler\\resimler\\camcorder.png"); // Varsayılan bir resim gösterir.
        }

        private void timer1_Tick(object sender, EventArgs e) // Zamanlayıcı tetiklendiğinde çalışır.
        {
            if (pctbox_kamera.Image != null) // Eğer görüntü kutusu boş değilse.
            {
                BarcodeReader reader = new BarcodeReader(); // Barkod okuyucu oluşturur.
                Result result = reader.Decode((Bitmap)pctbox_kamera.Image); // Görüntüden barkod okur.
                if (result != null) // Eğer bir barkod bulunursa.
                {
                    txt_barkod.Text = result.ToString(); // Barkod metnini kutuya yaz.
                    timer1.Stop(); // Zamanlayıcıyı durdur.
                }
            }
        }

        private void txt_barkod_TextChanged(object sender, EventArgs e) // Barkod metni değiştiğinde çalışır.
        {
            controller.Controller controller = new controller.Controller(); // Controller sınıfını başlatır.
            Urun hUrun = controller.urunuGetir(txt_barkod.Text); // Barkod bilgisini kullanarak ürünü getirir.
            lbl_urunisim.Text = hUrun.urunIsim.ToString(); // Ürün ismini etiket kutusuna yaz.
            txt_islem.Text = hUrun.fiyat.ToString(); // Ürün fiyatını işlem kutusuna yaz.
            SoundPlayer ses = new SoundPlayer(); // Ses çalma sınıfını oluşturur.
            ses.SoundLocation = "barkod.wav"; // Ses dosyasının yolunu ayarlar.
            ses.Play(); // Ses çalar.
        }

        private void btn_cikis_Click(object sender, EventArgs e) // Çıkış butonuna tıklandığında çalışır.
        {
            Form1 form1 = new Form1(); // Ana formu oluşturur.
            form1.Show(); // Ana formu gösterir.
            this.Hide(); // Mevcut formu gizler.
        }

        private void grp_urunler_Enter(object sender, EventArgs e) // Grup kutusuna girildiğinde çalışır (işlevsellik eklenmemiş).
        {
        }
    }
}
