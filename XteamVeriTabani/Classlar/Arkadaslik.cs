using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Arkadaslik
{
    public int IstekGonderenId { get; set; }

    public int IstekAlanId { get; set; }

    public int? DurumId { get; set; }

    public DateTime? ArkadaslikTarihi { get; set; }

    public virtual ArkadaslikDurum? Durum { get; set; }

    public virtual Oyuncu IstekAlan { get; set; } = null!;

    public virtual Oyuncu IstekGonderen { get; set; } = null!;
}
