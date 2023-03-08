using System;
using System.Collections.Generic;

namespace WSVENTA1.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
