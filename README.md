# 🎮 Xteam - Veritabanı Yönetim Sistemi Projesi

<div align="center">
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
  <img src="https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white" />
  <img src="https://img.shields.io/badge/Windows_Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white" />
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
</div>

## 📝 Proje Hakkında
Bu proje, Sakarya Üniversitesi BSM 211 Veritabanı Yönetim Sistemleri dersi kapsamında geliştirilmiş; oyuncuların oyun satın alabildiği, geliştiricilerin oyun yayınlayabildiği ve kullanıcılar arası etkileşimin (arkadaşlık sistemi) bulunduğu kapsamlı bir oyun platformu yönetim sistemidir. Tam olarak Steam gibi bir oyun kütüphanesi olmasa da temelde aynı işlevi görür.

Proje, **Database-First** yaklaşımıyla tasarlanmış olup **PostgreSQL** veritabanı ile **C# (Windows Form App)** uygulama arayüzünün entegrasyonunu içerir. Projede **16 adet varlık, 4 adet function ve tetikleyici (Triggers)** kullanılmıştır.

---

## 🛠️ Kullanılan Teknolojiler
* **Programlama Dili:** C#
* **Veritabanı:** PostgreSQL 
* **Veritabanı görüntüleme için:** Valentina Studio
* **Tasarım:** Draw.io

---

## 📐 Veritabanı Mimarisi
Veritabanı mimarisi aşağıdaki temel kurallar üzerine inşa edilmiştir:

* **Kalıtım (Genelleme):** HESAP tablosu altında OYUNCU ve GELISTIRICI olarak iki farklı kullanıcı türü tanımlanmıştır. İki tablonun da kendine özel (UNİQUE) özellikleri bulunmaktadır.
* **CRUD İşlemleri:** Uygulama üzerinden Oyun, Kategori ve Kullanıcı verileri için Arama, Ekleme, Silme ve Güncelleme modülleri mevcuttur. Database tarafından da yapılabilen bu işlemler uygulamada daha pratik şekilde yapılmaktadır.
* **Güvenlik ve Kontrol:**
  * Kullanıcıların e-posta ve kullanıcı adları eşsizdir (Unique).
  * Oyun fiyatları negatif olamaz (Check Constraint & Trigger).
  * Arkadaşlık isteklerinde bir kullanıcı kendisine istek gönderemez. Kendini arkadaş ekleyemez.

---

## ⚙️ İş Mantığı ve Veritabanı Yapıları
Projede iş mantığını veritabanı seviyesinde yönetmek için şu yapılar kullanılmıştır:

### 🔹 İşlevler (Functions)
* **fn_kayit_ol:** Yeni hesap oluşturur ve ilgili alt tabloya (Oyuncu/Geliştirici) otomatik ekleme yapar.
* **fn_giris_yap:** Kullanıcı kimlik doğrulamasını yapar ve giriş tarihini günceller.
* **fn_satin_al:** Sepetteki ürünlerin toplam tutarını hesaplar, bakiye kontrolü yapar ve satın alma işlemini gerçekleştirip sepeti temizler. Siparis detay tablosuna kaydeder , kütüphaneye kaydeder. 
* **fn_oyun_ara:** Metin ve kategori bazlı filtreleme ile oyun listeler.

### ⚡ Tetikleyiciler (Triggers)
* **trg_check_arkadas:** Kendine arkadaşlık isteği göndermeyi engeller.
* **trg_oyun_yuklendi:** Oyun durumu "Yüklü" yapıldığında indirilme sayısını otomatik artırır.
* **trg_kampanya_check:** Kampanya tarihlerinin mantıksal kontrolünü yapar.(başlangıç tarihi daha sonra yapılmasına izin verilmez)
* **trg_fiyat_guvenligi:** Negatif fiyat girişlerini veritabanı seviyesinde durdurur. (c# tarafından da 0 girilen değerler ÜCRETSİZ olarak değerlendirilir.)

---

## 🗂️ Veritabanı Şeması
Projenin ilişkisel şeması ve Crow's Foot gösterimine sahip ER diyagramı rapor dosyasında detaylandırılmıştır. Temel tablolar şunlardır: 

`HESAP`, `OYUNCU`, `GELISTIRICI`, `OYUN`, `KATEGORI`, `DIL`, `SEPET`, `SIPARIS`, `KAMPANYA`, `ARKADASLIK`.

---

## 🚀 Kurulum ve Çalıştırma
1. **Veritabanı:** PostgreSQL üzerinde rapor içerisindeki SQL dump kodunu önce CREATE DATABASE kısmı sonra geri kalan kısmı olacak şekilde çalıştırın.
2. Visual Studioyu açıp clone repo bölümünden repoyu projenize ekleyin.
3. `Oturum.cs` kısmındaki BaglantiCumlesi stringi kendi veri tabanı sunucusu bilgilerinize göre düzenleyin.

---

## 👥 Ekip
Bu proje BSM 211 Veritabanı Yönetim Sistemleri dersi için bir grup çalışmasıdır.

* Sinan ULUSİNAN
* Umut Can GÖKHAN
* Ahmet Faruk İKİZ
