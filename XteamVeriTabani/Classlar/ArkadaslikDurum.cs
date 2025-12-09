using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class ArkadaslikDurum
{
    public int DurumId { get; set; }

    public string DurumAdi { get; set; } = null!;

    public virtual ICollection<Arkadaslik> Arkadasliks { get; set; } = new List<Arkadaslik>();
}
