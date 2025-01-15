namespace tickets_cine.Models;

public partial class Pelicula
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public int Duracion {  get; set; }
    public string Genero { get; set; } = null!;
    public string Clasificacion { get; set; } = null!;
}
