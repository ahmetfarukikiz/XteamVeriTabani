using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Hesap
{
    public int Id { get; set; }

    public string Eposta { get; set; } = null!;

    public string HesapAdi { get; set; } = null!;

    public string KullaniciAdi { get; set; } = null!;

    public string Sifre { get; set; } = null!;

    public DateTime? KayitTarihi { get; set; }

    public DateTime? SonGiris { get; set; }

    public virtual Gelistirici? Gelistirici { get; set; }

    public virtual Oyuncu? Oyuncu { get; set; }
}
