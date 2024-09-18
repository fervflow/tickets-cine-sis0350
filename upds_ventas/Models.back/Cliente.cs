using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nit { get; set; }

    public virtual Persona IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
