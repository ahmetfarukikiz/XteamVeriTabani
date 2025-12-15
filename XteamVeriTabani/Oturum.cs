using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XteamVeriTabani;

public enum HesapTuru
{
    Belirsiz,
    Oyuncu,
    Gelistirici
}
public static class Oturum
{
    public static string BaglantiCumlesi = "Host=localhost;Username=postgres;Password=12345;Database=Xteam";
    public static int HesapID { get; set; }
    public static string? HesapAdi { get; set; }
    public static string? KullaniciAdi { get; set; }
    public static int Seviyesi { get; set; }
    public static string? EPosta { get; set; }
    public static string? WebSitesi { get; set; }
    public static string? VergiNo { get; set; }
    public static DateTime? KayitTarihi { get; set; }
    public static DateTime? SonGirisTarihi { get; set; }


    public static HesapTuru Tur { get; set; } = HesapTuru.Belirsiz;

    public static void GirisYap(int id, string hesapad, string kadi, string eposta, int seviye, HesapTuru rol, string? wbs = null, string? vn = null)
    {
        HesapID = id;
        HesapAdi = hesapad;
        KullaniciAdi = kadi;
        EPosta = eposta;
        Seviyesi = seviye;
        Tur = rol;
        if (IsGelistirici())
        {
            WebSitesi = wbs;
            VergiNo = vn;
        }
    }

    public static void CikisYap()
    {
        HesapID = 0;
        Seviyesi = 0;
        HesapAdi = null;
        KullaniciAdi = null;
        EPosta = null;
        WebSitesi = null;
        VergiNo = null;
        Tur = HesapTuru.Belirsiz;
    }

    public static bool IsGelistirici() => Tur == HesapTuru.Gelistirici;
    public static bool IsOyuncu() => Tur == HesapTuru.Oyuncu;
    
        
    
}
