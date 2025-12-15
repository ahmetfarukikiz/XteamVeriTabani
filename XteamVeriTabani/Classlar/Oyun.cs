using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Oyun
{
    public int OyunId { get; set; }




    public string ListeGorunumu
    {
        get
        {
            decimal hamFiyat = Fiyat.HasValue ? Fiyat.Value : 0;
            string gorunum = $"{Baslik}";

            if (hamFiyat == 0)
            {
                return $"{gorunum}  -  Ücretsiz";
            }

            if (IndirimOrani > 0)
            {
                decimal indirimMiktari = hamFiyat * IndirimOrani / 100;
                decimal indirimliFiyat = hamFiyat - indirimMiktari;

                string kampanyaMetni = !string.IsNullOrEmpty(KampanyaAdi) ? $" ({KampanyaAdi})" : "";

                return $"{gorunum}{kampanyaMetni}  {hamFiyat:N0} TL -> {indirimliFiyat:N2} TL   (%{IndirimOrani} indirim)";
            }

            return $"{gorunum}  -  {hamFiyat:N2} ₺";
        }
    }
    public int IndirimOrani { get; set; }

    public int GelistiriciId { get; set; }

    public int? KampanyaId { get; set; }

    public string KampanyaAdi { get; set; } //(Veritabanında yok, JOIN ile geliyor)

    public string Baslik { get; set; } = null!;

    public decimal? Fiyat { get; set; }

    public DateOnly? CikisTarihi { get; set; }

    public int? YuklemeBoyutu { get; set; }

    public string? Aciklama { get; set; }

    public int? IndirilmeSayisi { get; set; }

    public virtual Gelistirici Gelistirici { get; set; } = null!;

    public virtual Kampanya? Kampanya { get; set; }

    public virtual ICollection<OyunDil> OyunDils { get; set; } = new List<OyunDil>();

    public virtual ICollection<OyunKullanici> OyunKullanicis { get; set; } = new List<OyunKullanici>();

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<SiparisDetay> SiparisDetays { get; set; } = new List<SiparisDetay>();

    public virtual ICollection<Yorum> Yorums { get; set; } = new List<Yorum>();

    public virtual ICollection<Kategori> Kategoris { get; set; } = new List<Kategori>();
}
