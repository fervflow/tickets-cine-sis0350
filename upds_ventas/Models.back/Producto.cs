using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<DetalleVenta> DetatalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
