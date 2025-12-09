using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class OyunKullanici
{
    public int OyuncuId { get; set; }

    public int OyunId { get; set; }

    public DateTime? AlinmaTarihi { get; set; }

    public int? OynamaSuresi { get; set; }

    public int? DurumId { get; set; }

    public virtual OyunDurumu? Durum { get; set; }

    public virtual Oyun Oyun { get; set; } = null!;

    public virtual Oyuncu Oyuncu { get; set; } = null!;
}
