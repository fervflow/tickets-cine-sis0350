namespace tickets_cine.Models;

public partial class Horario
{
    public int Id { get; set; }
    public int SalaId { get; set; }
    public int PeliculaId { get; set; }
    public DateTime Fecha {  get; set; }
    public TimeSpan HoraInicio { get; set; }
    public decimal Precio {  get; set; }
    public virtual Sala? Sala { get; set; }
    public virtual Pelicula? Pelicula { get; set; }
}
