using System.ComponentModel.DataAnnotations;

public class Personas{

    [Key]
    public int PersonaId {get; set;}

    [Required(ErrorMessage = "El campo Nombre es requerido")]
    public string? Nombre {get; set;}
    public string? Telefono {get; set;}
    public string? Celular {get; set;}

    [Required(ErrorMessage = "El campo Email es requerido")]
    public string? Email {get; set;}

    public string? Direccion {get; set;}

    public DateTime FechaNacimiento {get; set;}
    public int OcupacionId {get; set;}
    
    public double Balance {get; set;}
}