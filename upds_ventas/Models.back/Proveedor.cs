using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }
    public string? Nit { get; set; }
    public string Nombre { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public string? Ciudad { get; set; }
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
