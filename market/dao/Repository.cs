using market.enumaration; // LoginStatus enumunu kullanmak için eklenmiş referans.
using market.model; // Model sınıflarını kullanmak için eklenmiş referans.
using System; // Sistem kütüphanelerini kullanmak için eklenmiş referans.
using System.Collections.Generic; // Liste gibi koleksiyon sınıfları için eklenmiş referans.
using System.Data.SqlClient; // SQL Server ile veri tabanı bağlantısı ve işlemlerini yapabilmek için eklenmiş referans.
using System.Linq;
using System.Runtime.Remoting.Messaging; // Uzaktan mesajlaşma sınıfları için eklenmiş referans.
using System.Text;
using System.Threading.Tasks;

namespace market.dao
{
    public class Repository
    {
        SqlConnection con; // Veritabanı bağlantı nesnesi.
        SqlCommand cmd; // SQL komutlarını çalıştırmak için kullanılır.
        SqlDataReader dr; // SQL sorgularından gelen veriyi okumak için kullanılır.
        int returnvalue; // Sorgulardan dönen değeri tutmak için kullanılır.
        List<LoginTable> loginTableList; // LoginTable nesnelerini tutan liste.

        // Constructor: Repository sınıfının başlangıç ayarları yapılıyor.
        public Repository()
        {
            con = new SqlConnection(@"Data Source=SEYFFRR;Initial Catalog=market;Integrated Security=True;"); // SQL Server bağlantı dizesi.
        }

        // Veritabanı bağlantısını açar veya kapatır.
        public void baglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open(); // Bağlantı kapalıysa aç.
            }
            else
            {
                con.Close(); // Bağlantı açıksa kapat.
            }
        }

        public User login(string kullaniciAdi, string sifre)
        {
            con.Open(); // Veritabanı bağlantısını aç.
            cmd = new SqlCommand("select * from loginTable where kullaniciAdi=@kulad and sifre=@sifre", con); // SQL sorgusu.
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi); // Parametre ekleme.
            cmd.Parameters.AddWithValue("@sifre", sifre);
            dr = cmd.ExecuteReader(); // Sorguyu çalıştır ve sonucu oku.

            if (dr.Read()) // Kullanıcı bulunduysa.
            {
                User user = new User(); // Yeni bir User nesnesi oluştur.
                user.id = int.Parse(dr["id"].ToString()); // Veritabanından id al.
                user.kullaniciAdi = dr["kullaniciAdi"].ToString(); // Kullanıcı adını al.
                user.sifre = dr["sifre"].ToString(); // Şifreyi al.
                user.yetki = dr["yetki"].ToString(); // Yetki bilgisi.
                user.emailAdres = dr["emailAdres"].ToString(); // E-posta adresi.
                user.guvenlikSorusu = dr["guvenlikSorusu"].ToString(); // Güvenlik sorusu.
                user.guvenlikCevabi = dr["guvenlikCevabi"].ToString(); // Güvenlik cevabı.
                user.status = LoginStatus.basarili; // Durum başarılı olarak atanıyor.
                return user; // Kullanıcı nesnesini dön.
            }
            else
            {
                User user = new User(); // Kullanıcı bulunamazsa yeni User nesnesi.
                user.status = LoginStatus.basarisiz; // Durum başarısız olarak atanıyor.
                return user;
            }
        }

        // LoginTable listesini getiren metod
        public List<LoginTable> getLoginTable()

        {
            loginTableList = new List<LoginTable>();// Listeyi oluştur.

            {
                try
                {

                    con.Open(); // Bağlantıyı aç.
                    cmd = new SqlCommand("guvenlikSorusuGetir_sp", con); // Stored Procedure kullanılıyor.
                    dr = cmd.ExecuteReader(); // Veriyi oku.
                    while (dr.Read())
                    {
                        LoginTable loginTable = new LoginTable(); // Yeni bir LoginTable nesnesi.
                        loginTable.id = int.Parse(dr["id"].ToString()); // ID değerini ata.
                        loginTable.kullaniciAdi = dr["kullaniciAdi"].ToString();
                        loginTable.sifre = dr["sifre"].ToString();
                        loginTable.yetki = dr["yetki"].ToString();
                        loginTable.emailAdres = dr["emailAdres"].ToString();
                        loginTable.guvenlikSorusu = dr["guvenlikSorusu"].ToString();
                        loginTable.guvenlikCevabi = dr["guvenlikCevabi"].ToString();
                        loginTableList.Add(loginTable); // Listeye ekle.
                    }
                    con.Close(); // Bağlantıyı kapat.
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata Oluştu"); // Hata durumunda mesaj yaz.
                }
                return loginTableList; // Listeyi geri dön.
            }




        }

        public LoginStatus doAuthentication(string kullaniciAdi, string guvenlikSorusu, string guvenlikCevabi)
        {
            con.Open(); // Veritabanı bağlantısını açar.
                        // Kullanıcı adı, güvenlik sorusu ve cevabı doğrulamak için sorgu oluşturur.
            cmd = new SqlCommand("select count(*) from loginTable where kullaniciAdi=@kulad and guvenlikSorusu=@guvSorusu and guvenlikCevabi=@guvCevabi", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi); // Kullanıcı adı parametresini ekler.
            cmd.Parameters.AddWithValue("@guvSorusu", guvenlikSorusu); // Güvenlik sorusu parametresini ekler.
            cmd.Parameters.AddWithValue("@guvCevabi", guvenlikCevabi); // Güvenlik cevabı parametresini ekler.
            returnvalue = (int)cmd.ExecuteScalar(); // Sorgudan dönen sonucu alır.
            con.Close(); // Veritabanı bağlantısını kapatır.

            // Sonuca göre doğrulama durumunu döndürür.
            if (returnvalue == 1)
            {
                return LoginStatus.basarili; // Doğrulama başarılı.
            }
            else
            {
                return LoginStatus.basarisiz; // Doğrulama başarısız.
            }
        }

        public LoginStatus changePassword(string kullaniciAdi, string sifre)
        {
            con.Open(); // Veritabanı bağlantısını açar.
                        // Şifre güncellemek için bir prosedür çağırır.
            cmd = new SqlCommand("sifreGuncelle_sp", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi); // Kullanıcı adı parametresini ekler.
            cmd.Parameters.AddWithValue("@sifre", sifre); // Yeni şifre parametresini ekler.
            returnvalue = cmd.ExecuteNonQuery(); // Sorguyu çalıştırır.
            con.Close(); // Veritabanı bağlantısını kapatır.
            return LoginStatus.basarili; // İşlem başarılı olarak döndürülür.
        }

        public string checkEmailAddress(string kullaniciAdi)
        {
            con.Open(); // Veritabanı bağlantısını açar.
                        // Kullanıcının email adresini sorgular.
            cmd = new SqlCommand("select emailAdres from loginTable where kullaniciAdi=@kulad", con);
            cmd.Parameters.AddWithValue("@kulad", kullaniciAdi); // Kullanıcı adı parametresini ekler.
            string emailAdres = (string)cmd.ExecuteScalar(); // Email adresini alır.
            con.Close(); // Veritabanı bağlantısını kapatır.

            return emailAdres; // Email adresini döndürür.
        }

        public Urun urunuGetir(string barkod)
        {
            con.Open(); // Veritabanı bağlantısını açar.
                        // Barkod numarasına göre ürün bilgilerini sorgular.
            cmd = new SqlCommand("select * from urun where barkodKod=@code", con);
            cmd.Parameters.AddWithValue("@code", barkod); // Barkod parametresini ekler.
            dr = cmd.ExecuteReader(); // Sorgu sonucunu okur.
            Urun urun = new Urun(); // Yeni bir ürün nesnesi oluşturur.

            while (dr.Read()) // Tüm sonuçları okur.
            {
                urun.id = dr["id"].ToString(); // Ürün ID'sini alır.
                urun.qrkod = dr["qrkod"].ToString(); // QR kodu alır.
                urun.barkodKod = dr["barkodKod"].ToString(); // Barkod kodunu alır.
                urun.urunIsim = dr["urunIsim"].ToString(); // Ürün ismini alır.
                urun.kilo = int.Parse(dr["kilo"].ToString()); // Ürün kilosunu alır.
                urun.fiyat = int.Parse(dr["fiyat"].ToString()); // Ürün fiyatını alır.
            }

            con.Close(); // Veritabanı bağlantısını kapatır.
            return urun; // Ürün bilgilerini döndürür.
        }

        public List<User> tumKullanicilariGetir()
        {
            List<User> userList = new List<User>(); // Kullanıcı listesini oluşturur.
            con.Open(); // Veritabanı bağlantısını açar.
            cmd = new SqlCommand("select * from loginTable", con); // Tüm kullanıcıları sorgular.
            dr = cmd.ExecuteReader(); // Sorgu sonucunu okur.

            while (dr.Read()) // Tüm sonuçları okur.
            {
                User user = new User(); // Yeni bir kullanıcı nesnesi oluşturur.
                user.id = int.Parse(dr["id"].ToString()); // Kullanıcı ID'sini alır.
                user.kullaniciAdi = dr["kullaniciAdi"].ToString(); // Kullanıcı adını alır.
                user.sifre = dr["sifre"].ToString(); // Şifreyi alır.
                user.yetki = dr["yetki"].ToString(); // Yetkiyi alır.
                user.bolge = dr["bolge"].ToString(); // Bölgeyi alır.
                user.emailAdres = dr["emailAdres"].ToString(); // Email adresini alır.
                user.guvenlikSorusu = dr["guvenlikSorusu"].ToString(); // Güvenlik sorusunu alır.
                user.guvenlikCevabi = dr["guvenlikCevabi"].ToString(); // Güvenlik cevabını alır.
                userList.Add(user); // Kullanıcıyı listeye ekler.
            }

            con.Close(); // Veritabanı bağlantısını kapatır.
            return userList; // Kullanıcı listesini döndürür.
        }

        public LoginStatus kullaniciEkle(User user)
        {
            con.Open(); // Veritabanı bağlantısını açar.

            cmd = new SqlCommand("sp_kullaniciEkle", con); // Kullanıcı ekleme prosedürünü çağırır.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kullaniciAdi", user.kullaniciAdi); // Kullanıcı adı parametresini ekler.
            cmd.Parameters.AddWithValue("@sifre", user.sifre); // Şifre parametresini ekler.
            cmd.Parameters.AddWithValue("@yetki", user.yetki); // Yetki parametresini ekler.
            cmd.Parameters.AddWithValue("@bolge", user.bolge); // Bölge parametresini ekler.
            cmd.Parameters.AddWithValue("@emailAdres", user.emailAdres); // Email adresi parametresini ekler.
            cmd.Parameters.AddWithValue("@guvenlikSorusu", user.guvenlikSorusu); // Güvenlik sorusu parametresini ekler.
            cmd.Parameters.AddWithValue("@guvenlikCevabi", user.guvenlikCevabi); // Güvenlik cevabı parametresini ekler.
            int returnvalue = cmd.ExecuteNonQuery(); // Sorguyu çalıştırır.
            con.Close(); // Veritabanı bağlantısını kapatır.

            // Sonuca göre durum döndürür.
            if (returnvalue == 1)
            {
                return LoginStatus.basarili; // Kullanıcı başarıyla eklendi.
            }
            else
            {
                return LoginStatus.basarisiz; // Kullanıcı eklenemedi.
            }
        }

        public LoginStatus kullaniciGuncelle(User user)
        {
            con.Open(); // Veritabanı bağlantısını açar.
            cmd = new SqlCommand("sp_kullaniciGuncelle", con); // Kullanıcı güncelleme prosedürünü çağırır.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", user.id); // Kullanıcı ID'sini parametre olarak ekler.
            cmd.Parameters.AddWithValue("@kullaniciAdi", user.kullaniciAdi); // Kullanıcı adını parametre olarak ekler.
            cmd.Parameters.AddWithValue("@sifre", user.sifre); // Şifreyi parametre olarak ekler.
            cmd.Parameters.AddWithValue("@yetki", user.yetki); // Yetkiyi parametre olarak ekler.
            cmd.Parameters.AddWithValue("@bolge", user.bolge); // Bölgeyi parametre olarak ekler.
            cmd.Parameters.AddWithValue("@emailAdres", user.emailAdres); // Email adresini parametre olarak ekler.
            cmd.Parameters.AddWithValue("@guvenlikSorusu", user.guvenlikSorusu); // Güvenlik sorusunu parametre olarak ekler.
            cmd.Parameters.AddWithValue("@guvenlikCevabi", user.guvenlikCevabi); // Güvenlik cevabını parametre olarak ekler.
            int returnvalue = cmd.ExecuteNonQuery(); // Sorguyu çalıştırır.
            con.Close(); // Veritabanı bağlantısını kapatır.

            // Sonuca göre durum döndürür.
            if (returnvalue == 1)
            {
                return LoginStatus.basarili; // Kullanıcı başarıyla güncellendi.
            }
            return LoginStatus.basarisiz; // Kullanıcı güncellenemedi.
        }

        public LoginStatus kullaniciSil(int id)
        {
            con.Open(); // Veritabanı bağlantısını açar.
                        // Kullanıcıyı silmek için sorgu oluşturur.
            cmd = new SqlCommand("delete from loginTable where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id); // Kullanıcı ID'sini parametre olarak ekler.
            int returnValue = cmd.ExecuteNonQuery(); // Sorguyu çalıştırır.
            con.Close(); // Veritabanı bağlantısını kapatır.

            // Sonuca göre durum döndürür.
            if (returnValue == 1)
            {
                return LoginStatus.basarili; // Kullanıcı başarıyla silindi.
            }
            else
            {
                return LoginStatus.basarisiz; // Kullanıcı silinemedi.
            }
        }

        public List<Urun> tumUrunleriGetir()
        {
            List<Urun> urunlist = new List<Urun>();

            con.Open();
            cmd = new SqlCommand("select * from urun",con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Urun urun = new Urun();
                urun.id = dr["id"].ToString();
                urun.qrkod = dr["qrkod"].ToString();
                urun.barkodKod = dr["barkodKod"].ToString();
                urun.olusturmaTarih =DateTime.Parse( dr["olusturma_Tarih"].ToString() );
                if (!string.IsNullOrEmpty(dr["guncelleme_Tarih"].ToString()) )
                {
                    urun.guncellemeTarih = DateTime.Parse(dr["guncelleme_Tarih"].ToString());
                }
                urun.urunIsim = dr["urunIsim"].ToString();
                urun.kilo =int.Parse( dr["kilo"].ToString());
                urun.fiyat = int.Parse(dr["fiyat"].ToString());
                if (!string.IsNullOrEmpty(dr["ciro"].ToString()))
                {
                    urun.ciro = int.Parse(dr["ciro"].ToString());
                    {
                        urun.ciro = int.Parse(dr["ciro"].ToString());

                    }
                }
                urunlist.Add(urun);
            }
            con.Close();
            return urunlist;
        }

       public LoginStatus urunEkle(Urun urun)
        {
            con.Open();
            cmd = new SqlCommand("sp_urunEkle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",urun.id);
            cmd.Parameters.AddWithValue("@urunIsim", urun.urunIsim);
            cmd.Parameters.AddWithValue("@qrkod", urun.qrkod);
            cmd.Parameters.AddWithValue("@barkodKod", urun.barkodKod);
            cmd.Parameters.AddWithValue("@olusturma_Tarih", urun.olusturmaTarih);
            cmd.Parameters.AddWithValue("@guncellemee_Tarih", urun.guncellemeTarih);
            cmd.Parameters.AddWithValue("@kilo", urun.kilo);
            cmd.Parameters.AddWithValue("@fiyat", urun.fiyat);
            cmd.Parameters.AddWithValue("@ciro", urun.ciro);
            int returnvalue =cmd.ExecuteNonQuery();
            con.Close() ;
            if(returnvalue==1)
            {
                return LoginStatus.basarili;
            }
            return LoginStatus.basarisiz;
        }
        public LoginStatus urunGuncelle(Urun urun)
        {
            con.Open();
            cmd = new SqlCommand("sp_urunGuncelle", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", urun.id);
            cmd.Parameters.AddWithValue("@urunIsim", urun.urunIsim);
            cmd.Parameters.AddWithValue("@qrkod", urun.qrkod);
            cmd.Parameters.AddWithValue("@barkodKod", urun.barkodKod);
            cmd.Parameters.AddWithValue("@olusturma_Tarih", urun.olusturmaTarih);
            cmd.Parameters.AddWithValue("@guncelleme_Tarih", urun.guncellemeTarih);
            cmd.Parameters.AddWithValue("@kilo", urun.kilo);
            cmd.Parameters.AddWithValue("@fiyat", urun.fiyat);
            cmd.Parameters.AddWithValue("@ciro", urun.ciro);
            int returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return LoginStatus.basarili;
            }
            return LoginStatus.basarisiz;
        }
        public LoginStatus urunSil(string id)
        {
            con.Open();
            cmd = new SqlCommand("delete from urun where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int returnvalue = cmd.ExecuteNonQuery();
            con.Close();
            if (returnvalue == 1)
            {
                return LoginStatus.basarili;
            }
            return LoginStatus.basarisiz;
        }
    
    }

    
}