namespace tickets_cine.Models;

public partial class Ticket
{
    public int TicketId { get; set; }
    public int ClienteId { get; set; }
    public int UsuarioId { get; set; }
    public int HorarioId { get; set; }
    public int AsientoId { get; set; }
    public DateTime FechaCompra { get; set; } = DateTime.Now;
    public decimal PrecioTotal { get; set; }

    public virtual Cliente? Cliente { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public virtual Horario? Horario { get; set; }
    public virtual Asiento? Asiento { get; set; }
}

