using System; // Temel C# sınıfları için gerekli.
using System.Collections.Generic; // Koleksiyonlar için gerekli.
using System.Linq; // LINQ sorguları için gerekli.
using System.Text; // Metin işleme için gerekli.
using System.Threading.Tasks; // Çoklu görev işlemleri için gerekli.

namespace market.model // Proje içerisindeki model sınıflarını temsil eden ad alanı.
{
    public class LoginTable // Kullanıcı giriş bilgilerini temsil eden sınıf.
    {
        public int id { get; set; } // Kullanıcı için benzersiz kimlik numarası.
                                    // "get" özelliği, bu özelliğin değerini okumak için kullanılır.
                                    // "set" özelliği, bu özelliğe yeni bir değer atamak için kullanılır.

        public string kullaniciAdi { get; set; } // Kullanıcının giriş için kullandığı kullanıcı adı.
                                                 // "get" ve "set" ile kullanıcı adı okunabilir ve yazılabilir.

        public string sifre { get; set; } // Kullanıcının giriş şifresi.
                                          // "get" ve "set" özelliği ile şifre değerine erişilir ve güncellenir.

        public string yetki { get; set; } // Kullanıcının yetki türü (ör. admin, kasiyer).
                                          // "get" ve "set" özelliği yetki bilgisini yönetmek için kullanılır.

        public string emailAdres { get; set; } // Kullanıcının e-posta adresi.
                                               // "get" özelliği e-posta değerini okumak için, "set" özelliği ise yazmak için kullanılır.

        public string guvenlikSorusu { get; set; } // Kullanıcıya sorulacak güvenlik sorusu.
                                                   // "get" ve "set" ile güvenlik sorusu bilgisine erişim sağlanır.

        public string guvenlikCevabi { get; set; } // Kullanıcının güvenlik sorusuna verdiği cevap.
                                                   // "get" özelliği cevap bilgisini almak, "set" özelliği ise atamak için kullanılır.
    }
}
