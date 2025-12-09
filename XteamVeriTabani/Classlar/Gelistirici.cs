using System;
using System.Collections.Generic;

namespace XteamVeriTabani.Models;

public partial class Gelistirici
{
    public int GelistiriciId { get; set; }

    public string? VergiNo { get; set; }

    public string? WebSitesi { get; set; }

    public virtual Hesap GelistiriciNavigation { get; set; } = null!;

    public virtual ICollection<Oyun> Oyuns { get; set; } = new List<Oyun>();
}
