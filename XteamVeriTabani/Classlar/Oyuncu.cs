using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Oyuncu
{
    public int OyuncuId { get; set; }

    public int? Seviye { get; set; }

    public decimal? CuzdanBakiyesi { get; set; }

    public virtual ICollection<Arkadaslik> ArkadaslikIstekAlans { get; set; } = new List<Arkadaslik>();

    public virtual ICollection<Arkadaslik> ArkadaslikIstekGonderens { get; set; } = new List<Arkadaslik>();

    public virtual ICollection<OyunKullanici> OyunKullanicis { get; set; } = new List<OyunKullanici>();

    public virtual Hesap OyuncuNavigation { get; set; } = null!;

    public virtual ICollection<Sepet> Sepets { get; set; } = new List<Sepet>();

    public virtual ICollection<Sipari> Siparis { get; set; } = new List<Sipari>();

    public virtual ICollection<Yorum> Yorums { get; set; } = new List<Yorum>();
}
