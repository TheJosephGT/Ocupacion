using System.ComponentModel.DataAnnotations;

public class Persona{

    [Key]
    public int PersonaId {get; set;}
    [Required(ErrorMessage = "El campo PersonaId es requerido")]

    public string? Nombre {get; set;}

    public string? Telefono {get; set;}

    public string? Celular {get; set;}

    public string? Email {get; set;}

    public string? Direccion {get; set;}

    public string? FechaNacimiento {get; set;}

    public int OcupacionId {get; set;}
}