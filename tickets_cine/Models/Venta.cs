namespace upds_ventas.Models;

public partial class Venta
{
    public int? IdCliente { get; set; }
    public int? IdUsuario { get; set; }
    public int IdVenta { get; set; }
    public DateTime Fecha { get; set; }
    public decimal? Total { get; set; }
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
    public virtual Cliente? Cliente { get; set; }
    public virtual Usuario? Usuario { get; set; }
}
