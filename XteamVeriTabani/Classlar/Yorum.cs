using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Yorum
{
    public int YorumId { get; set; }

    public int? OyunId { get; set; }

    public int? OyuncuId { get; set; }

    public string YorumMetni { get; set; } = null!;

    public DateTime? Tarih { get; set; }

    public virtual Oyun? Oyun { get; set; }

    public virtual Oyuncu? Oyuncu { get; set; }
}
