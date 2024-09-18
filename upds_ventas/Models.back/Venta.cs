using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Venta
{
    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public int IdVenta { get; set; }

    public DateTime Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleVenta> DetatalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
