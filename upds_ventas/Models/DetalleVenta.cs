namespace upds_ventas.Models;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }
    public int? IdVenta { get; set; }
    public int? IdProducto { get; set; }
    public int? Cantidad { get; set; }
    public decimal? SubTotal { get; set; }
    public virtual Producto? Producto { get; set; }
    public virtual Venta? Venta { get; set; }
}
