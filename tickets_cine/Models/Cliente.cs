namespace tickets_cine.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }
    //public string? Nit { get; set; }
    public virtual Persona Persona { get; set; } = null!;
}
