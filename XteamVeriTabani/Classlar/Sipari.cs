using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Sipari
{
    public int SiparisId { get; set; }

    public int OyuncuId { get; set; }

    public decimal? ToplamTutar { get; set; }

    public DateTime? SiparisTarihi { get; set; }

    public virtual Oyuncu Oyuncu { get; set; } = null!;

    public virtual ICollection<SiparisDetay> SiparisDetays { get; set; } = new List<SiparisDetay>();
}
