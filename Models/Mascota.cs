using System.ComponentModel.DataAnnotations;

namespace parcial_programacion.Models;

public class Mascota
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Escribe el nombre de la mascota.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Escribe la especie de la mascota.")]
    public string Especie { get; set; } = string.Empty;

    [Required(ErrorMessage = "Escribe la raza de la mascota.")]
    public string Raza { get; set; } = string.Empty;

    [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100 años.")]
    public int Edad { get; set; }
}