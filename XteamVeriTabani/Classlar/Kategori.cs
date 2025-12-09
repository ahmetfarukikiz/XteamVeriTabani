using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Kategori
{
    public int KategoriId { get; set; }

    public string TurAdi { get; set; } = null!;

    public virtual ICollection<Oyun> Oyuns { get; set; } = new List<Oyun>();
}
