Xteam - Veritabanı Yönetim Sistemi Projesi
Bu proje, Sakarya Üniversitesi BSM 211 Veritabanı Yönetim Sistemleri dersi kapsamında geliştirilmiş; oyuncuların oyun satın alabildiği, geliştiricilerin oyun yayınlayabildiği ve kullanıcılar arası etkileşimin (arkadaşlık sistemi) bulunduğu kapsamlı bir oyun platformu yönetim sistemidir. Tam olarak Steam gibi bir oyun kütüphanesi olmasa da temelde aynı işlevi görür.

Proje, Database-First yaklaşımıyla tasarlanmış olup PostgreSQL veritabanı ile C# (Windows Forms/Console) uygulama arayüzünün entegrasyonunu içerir. Toplamda 15'ten fazla tablo (ödev şartı), gelişmiş saklı yordamlar (Stored Procedures) ve tetikleyiciler (Triggers) kullanılarak(4 trigger 4 saklı yordam) güçlü bir iş mantığı kurulmuştur.

Kullanılan Teknolojiler
* Programlama Dili: C#
* Veritabanı: PostgreSQL 
* Veritabanı görüntüleme için : Valentina Studio
* Tasarım: Draw.io

Veritabanı mimarisi aşağıdaki temel kurallar üzerine inşa edilmiştir:
* Kalıtım (Genelleme): HESAP tablosu altında OYUNCU ve GELISTIRICI olarak iki farklı kullanıcı türü tanımlanmıştır. İki tablonun da kendine özel (UNİQUE) özellikleri bulunmaktadır.
* CRUD İşlemleri: Uygulama üzerinden Oyun, Kategori ve Kullanıcı verileri için Arama, Ekleme, Silme ve Güncelleme modülleri mevcuttur. Database tarafından da yapılabilen bu işlemler uygulamada daha pratik şekilde yapılmaktadır.
* Güvenlik ve Kontrol: * Kullanıcıların e-posta ve kullanıcı adları eşsizdir (Unique).
* Oyun fiyatları negatif olamaz (Check Constraint & Trigger).
* Arkadaşlık isteklerinde bir kullanıcı kendisine istek gönderemez. Kendini arkadaş ekleyemez.

Projede iş mantığını veritabanı seviyesinde yönetmek için şu yapılar kullanılmıştır:
** Saklı Yordamlar (Functions)
* sp_kayit_ol: Yeni hesap oluşturur ve ilgili alt tabloya (Oyuncu/Geliştirici) otomatik ekleme yapar.
* sp_giris_yap: Kullanıcı kimlik doğrulamasını yapar ve giriş tarihini günceller.
* sp_satin_al: Sepetteki ürünlerin toplam tutarını hesaplar, bakiye kontrolü yapar ve satın alma işlemini gerçekleştirip sepeti temizler. Siparis detay tablosuna kaydeder , kütüphaneye kaydeder. 
* sp_oyun_ara: Metin ve kategori bazlı filtreleme ile oyun listeler.

** Tetikleyiciler (Triggers)
* trg_check_arkadas: Kendine arkadaşlık isteği göndermeyi engeller.
* trg_oyun_yuklendi: Oyun durumu "Yüklü" yapıldığında indirilme sayısını otomatik artırır.
* trg_kampanya_check: Kampanya tarihlerinin mantıksal kontrolünü yapar.(başlangıç tarihi daha sonra yapılmasına izin verilmez)
* trg_fiyat_guvenligi: Negatif fiyat girişlerini veritabanı seviyesinde durdurur. (c# tarafından da 0 girilen değerler ÜCRETSİZ olarak değerlendirilir.)

Projenin ilişkisel şeması ve Crow's Foot gösterimine sahip ER diyagramı rapor dosyasında detaylandırılmıştır. Temel tablolar şunlardır: HESAP, OYUNCU, GELISTIRICI, OYUN, KATEGORI, DIL, SEPET, SIPARIS, KAMPANYA, ARKADASLIK.

Kurulum ve Çalıştırma :
* Veritabanı: PostgreSQL üzerinde rapor içerisindeki SQL dump dosyasını çalıştırarak tabloları ve fonksiyonları oluşturun.
* Uygulama: XteamVeriTabani.sln dosyasını Visual Studio ile açın.
* Bağlantı: Veritabanı bağlantı dizesini (Connection String) kendi yerel PostgreSQL bilgilerinizle güncelleyin. Kendi postgre localhost şifrenizle yapın. 
* Çalıştır: Projeyi derleyin ve başlatın.

Bu proje BSM 211 Veritabanı Yönetim Sistemleri dersi için bir grup çalışmasıdır. Sinan ULUSİNAN / Umut Can GÖKHAN / Ahmet Faruk İKİZ
