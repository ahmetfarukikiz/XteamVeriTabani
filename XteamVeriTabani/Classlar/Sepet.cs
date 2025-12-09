using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Sepet
{
    public int SepetId { get; set; }

    public int OyuncuId { get; set; }

    public int OyunId { get; set; }

    public DateTime? EklenmeTarihi { get; set; }

    public virtual Oyun Oyun { get; set; } = null!;

    public virtual Oyuncu Oyuncu { get; set; } = null!;
}
