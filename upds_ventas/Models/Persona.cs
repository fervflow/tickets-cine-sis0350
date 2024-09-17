using System;
using System.Collections.Generic;

namespace upds_ventas.Models;

public partial class Persona
{
    public int IdPersona { get; set; }
    public string? Ci { get; set; }
    public string Nombre { get; set; } = null!;
    public string ApPaterno { get; set; } = null!;
    public string? ApMaterno { get; set; }
    public virtual Cliente? Cliente { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
