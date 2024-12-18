using market.controller; // Controller sınıfını kullanmak için gerekli.
using market.enumaration; // Enumaration sınıfını kullanmak için gerekli.
using market.model; // Model sınıflarını kullanmak için gerekli.
using System; // Temel C# sınıflarını kullanmak için gerekli.
using System.Collections.Generic; // List gibi koleksiyonlar için gerekli.
using System.ComponentModel; // Bileşen model desteği sağlar.
using System.Data; // Veritabanı işlemleri için gerekli.
using System.Drawing; // Grafik ve görsel işleme için gerekli.
using System.Linq; // LINQ sorguları için gerekli.
using System.Net.Mail; // E-posta gönderimi için gerekli.
using System.Net; // Ağ işlemleri için gerekli.
using System.Text; // Metin işleme için gerekli.
using System.Threading.Tasks; // Çoklu görev işleme için gerekli.
using System.Windows.Forms; // Windows Forms desteği sağlar.
using System.Diagnostics.Eventing.Reader; // Olay günlüğü işleme için gerekli.

namespace market
{
    public partial class SifreDegistirme : Form // Şifre değiştirme işlemini gerçekleştiren form.
    {
        int code; // Doğrulama kodunu saklar.

        public SifreDegistirme() // Constructor metodu.
        {
            InitializeComponent(); // Bileşenlerin başlatılmasını sağlar.
        }

        private void SifreDegistirme_Load(object sender, EventArgs e) // Form yüklendiğinde çalışır.
        {
            Controller controller = new Controller(); // Controller sınıfını başlatır.

            List<LoginTable> loginTableList = controller.getLoginTable(); // Login tablosundaki kayıtları alır.

            grpBox_mailAlani.Enabled = false; // Mail alanını devre dışı bırakır.
            grpBox_sifreDegistirmeAlani.Enabled = false; // Şifre değiştirme alanını devre dışı bırakır.

            foreach (LoginTable lt in loginTableList) // Güvenlik sorularını combobox'a ekler.
            {
                cmbBox_guvenlikSorusu.Items.Add(lt.guvenlikSorusu.ToString());
            }
            cmbBox_guvenlikSorusu.SelectedIndex = 0; // İlk seçeneği varsayılan yapar.
        }

        private void label7_Click(object sender, EventArgs e) // Label tıklandığında çalışır (boş).
        {
        }

        private void button1_Click(object sender, EventArgs e) // Kullanıcı kimlik doğrulaması yapar.
        {
            Controller controller = new Controller(); // Controller sınıfını başlatır.
            LoginStatus result = controller.doAuthentication(
                txt_kullaniciAdi.Text.Trim().ToLower(),
                cmbBox_guvenlikSorusu.SelectedItem.ToString(),
                txt_guvenlikCevabi.Text.ToLower());

            if (result == LoginStatus.basarili) // Kimlik doğrulaması başarılıysa.
            {
                grpBox_mailAlani.Enabled = true; // Mail alanını etkinleştirir.
            }
            else if (result == LoginStatus.basarisiz) // Kimlik doğrulaması başarısızsa.
            {
                MessageBox.Show("Girdiğiniz Bilgileri Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // Alanlar eksikse.
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_dogrulamaGonder_Click(object sender, EventArgs e) // Doğrulama kodu gönderir.
        {
            Controller controller = new Controller(); // Controller sınıfını başlatır.
            string emailAdres = controller.checkEmailAddress(txt_kullaniciAdi.Text); // Kullanıcının email adresini alır.

            if (emailAdres == txt_emailAdres.Text) // Email adresi doğrulanırsa.
            {
                try
                {
                    Random rdn = new Random(); // Rastgele sayı üretici.
                    code = rdn.Next(111111, 999999); // Doğrulama kodunu oluşturur.

                    MailAddress mailAlan = new MailAddress(txt_emailAdres.Text, txt_kullaniciAdi.Text); // Alıcı email adresi.
                    MailAddress mailGonderen = new MailAddress("seyfullah.ercicek2010@gmail.com", "Seyfullah Erçiçek"); // Gönderici email adresi.
                    MailMessage mesaj = new MailMessage(); // Email mesajı.

                    mesaj.To.Add(mailAlan); // Alıcı eklenir.
                    mesaj.From = mailGonderen; // Gönderici eklenir.
                    mesaj.Subject = "Şifre Değiştirme"; // Email konusu.
                    mesaj.Body = "Şifrenizi değiştirmek için doğrulama kodunuz: " + code; // Email içeriği.

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587) // SMTP ayarları.
                    {
                        Credentials = new NetworkCredential("seyfullah.ercicek2010@gmail.com", "ywsr qdwv ppqe lons\r\n"), // Gönderici kimlik bilgileri.
                        EnableSsl = true // Güvenli bağlantı.
                    };

                    smtp.Send(mesaj); // Email gönderilir.
                    MessageBox.Show("Doğrulama Kodu Gönderildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) // Hata durumunda.
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Email adresi yanlışsa.
            {
                MessageBox.Show("Hesabınıza Bağlı Mail Adresini Doğru Girdiğinizden Emin Olun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*
        Random rdn = new Random();
        int code=rdn.Next(111111,999999);

        MailAddress mailAlan = new MailAddress(txt_emailAdres.Text, "Ahmet Veli");
        MailAddress mailGonderen = new MailAddress("seyfo6551@hotmail.com", "Seyfullah Erçiçek");
        MailMessage mesaj = new MailMessage();

        mesaj.To.Add(mailAlan);
        mesaj.From = mailGonderen;
        mesaj.Subject = "Şifre Değiştirme";
        mesaj.Body = "Şifrenizi Değiştirmek için doğrulama kodunuz :" + code;




        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new System.Net.NetworkCredential("seyfullah.ercicek2010@gmail.com", "ywsr qdwv ppqe lons\r\n");
        smtp.EnableSsl = true;
        smtp.Send(mesaj);
        MessageBox.Show("Doğrulama Kodu Gönderildi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        */




        private void btn_onayla_Click(object sender, EventArgs e) // Doğrulama kodunu onaylar.
        {
            if (txt_dogrulamaKodu.Text == code.ToString()) // Doğrulama kodu doğruysa.
            {
                grpBox_sifreDegistirmeAlani.Enabled = true; // Şifre değiştirme alanını etkinleştirir.
            }
            else // Doğrulama kodu yanlışsa.
            {
                MessageBox.Show("Doğrulama Kodunu Hatalı Girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_degistir_Click(object sender, EventArgs e) // Şifre değiştirme işlemini gerçekleştirir.
        {
            Controller controller = new Controller(); // Controller sınıfını başlatır.

            if (txt_yeniSifre.Text == txt_yeniSifreTekrar.Text) // Şifreler uyuşuyorsa.
            {
                LoginStatus result = controller.changePassword(txt_kullaniciAdi.Text, txt_yeniSifre.Text); // Şifre değiştirilir.

                if (result == LoginStatus.basarili) // İşlem başarılıysa.
                {
                    MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // İşlem başarısızsa.
                {
                    MessageBox.Show("Gerekli Alanları Doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Şifreler uyuşmuyorsa.
            {
                MessageBox.Show("Girdiğiniz Şifreler Birbirinden Farklı Olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e) // Giriş ekranına geri döner.
        {
            Form1 form1 = new Form1(); // Giriş ekranı formunu açar.
            form1.Show(); // Giriş ekranını gösterir.
            this.Hide(); // Mevcut formu gizler.
        }

        private void groupBox1_Enter(object sender, EventArgs e) // GroupBox içine girildiğinde çalışır (boş).
        {
        }
    }
}
