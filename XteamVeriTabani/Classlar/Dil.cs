using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Dil
{
    public int DilId { get; set; }

    public string DilAdi { get; set; } = null!;

    public virtual ICollection<OyunDil> OyunDils { get; set; } = new List<OyunDil>();
}
