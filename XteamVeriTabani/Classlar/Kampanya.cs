using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Kampanya
{
    public int KampanyaId { get; set; }

    public string? Baslik { get; set; }

    public DateTime? BaslangicTarihi { get; set; }

    public DateTime? BitisTarihi { get; set; }

    public bool? AktifMi { get; set; }

    public virtual ICollection<Oyun> Oyuns { get; set; } = new List<Oyun>();
}
