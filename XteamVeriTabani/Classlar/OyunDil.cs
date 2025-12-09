using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class OyunDil
{
    public int OyunId { get; set; }

    public int DilId { get; set; }

    public bool? AltyaziVarMi { get; set; }

    public bool? SeslendirmeVarMi { get; set; }

    public virtual Dil Dil { get; set; } = null!;

    public virtual Oyun Oyun { get; set; } = null!;
}
