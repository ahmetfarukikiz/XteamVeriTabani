using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Oyun
{
    public int OyunId { get; set; }

    public int GelistiriciId { get; set; }

    public int? KampanyaId { get; set; }

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
