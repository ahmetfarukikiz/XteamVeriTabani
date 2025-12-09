using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class SiparisDetay
{
    public int DetayId { get; set; }

    public int SiparisId { get; set; }

    public int OyunId { get; set; }

    public decimal SatisFiyati { get; set; }

    public virtual Oyun Oyun { get; set; } = null!;

    public virtual Sipari Siparis { get; set; } = null!;
}
