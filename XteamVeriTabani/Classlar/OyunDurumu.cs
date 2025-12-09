using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class OyunDurumu
{
    public int DurumId { get; set; }

    public string DurumAdi { get; set; } = null!;

    public virtual ICollection<OyunKullanici> OyunKullanicis { get; set; } = new List<OyunKullanici>();
}
