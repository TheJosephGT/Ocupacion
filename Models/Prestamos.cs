using System.ComponentModel.DataAnnotations;

//Campos: PrestamoId,Fecha,Vence, PersonaId,Concepto,Monto,Balance;
public class Prestamos{
    [Key]
    public int PrestamoId {get; set;}

    public DateTime? Fecha {get;set;}

    public DateTime? Vence {get;set;}

    [Required(ErrorMessage = "El campo PersonaId es requerido")]
    public int PersonaId {get; set;}

    [Required(ErrorMessage = "El campo Concepto es requerido")]
    public string? Concepto {get; set;}

    [Required(ErrorMessage = "El campo Monto es requerido")]
    public double Monto {get; set;}

    [Required(ErrorMessage = "El campo balance es requerido")]
    public double Balance {get; set;}

}