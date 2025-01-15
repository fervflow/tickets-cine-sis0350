namespace tickets_cine.Models;

public partial class Asiento
{
    public int Id { get; set; }
    public int SalaId { get; set; }
    public string Codigo { get; set; } = null!;
    public bool Ocupado { get; set; }
    public virtual Sala? Sala { get; set; }
}
