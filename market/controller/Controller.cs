using market.dao; // Repository sınıfını kullanmak için eklenmiş referans.
using market.enumaration; // LoginStatus enumunu kullanmak için eklenmiş referans.
using market.model; // Model sınıflarını kullanmak için eklenmiş referans.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace market.controller
{
    // Controller sınıfı, iş mantığını yönetir ve Repository sınıfı ile model arasında bir köprü kurar.
    public class Controller
    {
        Repository repository; // Repository sınıfından bir nesne oluşturularak veritabanı işlemleri gerçekleştirilecek.

        // Constructor (Yapıcı Metot)
        public Controller()
        {
            repository = new Repository(); // Repository nesnesi oluşturuluyor.
        }

        // Kullanıcı girişi için kullanılan metod.
        public User login(string kullaniciAdi, string sifre)
        {
            User result; // Giriş sonucu dönecek olan User nesnesi.
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(sifre)) // Kullanıcı adı ve şifre kontrolü
            {
                result = repository.login(kullaniciAdi, sifre); // Repository'den giriş kontrolü yapılır.
                return result; // Giriş başarılıysa User nesnesi döner.
            }
            else
            {
                User user = new User(); // Eksik parametre durumunda boş User nesnesi döner.
                user.status = LoginStatus.eksikParametre; // Kullanıcı durumu eksikParametre olarak atanır.
                return user;
            }
        }

        // LoginTable listesini getiren metod.
        public List<LoginTable> getLoginTable()
        {
            List<LoginTable> loginTableList = repository.getLoginTable(); // Repository'den LoginTable listesi alınır.
            return loginTableList; // Liste geri dönülür.
        }

        // Kimlik doğrulama işlemi yapan metod.
        public LoginStatus doAuthentication(string kullaniciAdi, string guvenlikSorusu, string guvenlikCevabi)
        {
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(guvenlikSorusu) && !string.IsNullOrEmpty(guvenlikCevabi))
            {
                LoginStatus result = repository.doAuthentication(kullaniciAdi, guvenlikSorusu, guvenlikCevabi); // Doğrulama işlemi yapılır.

                if (result == LoginStatus.basarili) // Sonuç kontrolü.
                {
                    return result; // Doğrulama başarılıysa geri dön.
                }
                else
                {
                    return LoginStatus.basarisiz; // Doğrulama başarısızsa geri dön.
                }
            }
            else
            {
                return LoginStatus.eksikParametre; // Parametreler eksikse geri döner.
            }
        }

        // Kullanıcı şifresini değiştiren metod.
        public LoginStatus changePassword(string kullaniciAdi, string sifre)
        {
            if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(sifre))
            {
                return repository.changePassword(kullaniciAdi, sifre); // Repository ile şire değiştirme işlemi.
            }
            else
            {
                return LoginStatus.eksikParametre; // Parametre eksikse durum dönülür.
            }
        }

        // E-posta adresini kontrol eden metod.
        public string checkEmailAddress(string kullaniciAdi)
        {
            return repository.checkEmailAddress(kullaniciAdi); // Kullanıcının e-posta adresi kontrol edilip dönülür.
        }

        // Barkod ile ürün getiren metod.
        public Urun urunuGetir(string barkod)
        {
            if (!string.IsNullOrEmpty(barkod))
            {
                return repository.urunuGetir(barkod); // Barkoda göre ürün getirme işlemi.
            }
            return null; // Barkod boşsa null dön.
        }

        // Tüm kullanıcıları getiren metod.
        public List<User> tumKullanicilariGetir()
        {
            return repository.tumKullanicilariGetir(); // Tüm kullanıcıları repository'den alır ve döner.
        }

        // Yeni kullanıcı ekleyen metod.
        public LoginStatus kullaniciEkle(User user)
        {
            if (!string.IsNullOrEmpty(user.kullaniciAdi) && !string.IsNullOrEmpty(user.sifre) &&
                !string.IsNullOrEmpty(user.emailAdres) && !string.IsNullOrEmpty(user.guvenlikSorusu) &&
                !string.IsNullOrEmpty(user.guvenlikCevabi))
            {
                return repository.kullaniciEkle(user); // Kullanıcı ekleme işlemi yapılır.
            }
            else
            {
                return LoginStatus.eksikParametre; // Parametre eksikse durum dönülür.
            }
        }

        // Kullanıcıyı güncelleyen metod.
        public LoginStatus kullaniciGuncelle(User user)
        {
            return repository.kullaniciGuncelle(user); // Kullanıcı bilgilerini repository'de günceller.
        }

        // Kullanıcıyı silen metod.
        public LoginStatus kullaniciSil(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return repository.kullaniciSil(id); // Kullanıcıyı ID'ye göre siler.
            }
            else
            {
                return LoginStatus.eksikParametre; // Eksik parametre durumu dönülür.
            }
        }
        public List<Urun> tumUrunleriGetir()
        {
            return repository.tumUrunleriGetir();
            
        }

        public LoginStatus urunEkle(Urun urun)
        {
            if(!string.IsNullOrEmpty(urun.id)&& !string.IsNullOrEmpty(urun.urunIsim)&& !string.IsNullOrEmpty(urun.barkodKod))
            {
                return repository.urunEkle(urun);

            }
            else
            {
                return LoginStatus.eksikParametre;
            }
        }
        public LoginStatus urunGuncelle(Urun urun)
        {
            if(!string.IsNullOrEmpty(urun.id) && !string.IsNullOrEmpty(urun.urunIsim) && !string.IsNullOrEmpty(urun.barkodKod))
            {
                return repository.urunGuncelle(urun);
            }
            else
            {
                return LoginStatus.eksikParametre;
            }
        }
        public LoginStatus urunSil(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return repository.urunSil(id);
            }
            else
            {
                return LoginStatus.eksikParametre;
            }
                
        }
    }
}
