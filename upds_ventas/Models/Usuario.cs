using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
    public byte[] Pass { get; set; } = null!;
    public string? Tipo { get; set; }
    public bool Estado { get; set; }
    public virtual Persona IdUsuarioNavigation { get; set; } = null!;
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
