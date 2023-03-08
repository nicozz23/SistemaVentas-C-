using System;
using System.Collections.Generic;

namespace WSVENTA1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Costo { get; set; }
}
