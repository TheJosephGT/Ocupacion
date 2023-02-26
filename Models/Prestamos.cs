using System.ComponentModel.DataAnnotations;

//Campos: PrestamoId,Fecha,Vence, PersonaId,Concepto!!!,Monto!!!,Balance!!;
public class Prestamos{
    [Key]
    public int PrestamoId {get; set;}

    public DateTime Fecha {get;set;}

    public DateTime Vence {get;set;}

    public int PersonaId {get; set;}

    [Required(ErrorMessage = "El campo Concepto es requerido")]
    public string? Concepto {get; set;}

    [Range(0.01, double.MaxValue, ErrorMessage = "El monto NO es valido")]
    public double Monto {get; set;}

    [Range(0.01, double.MaxValue, ErrorMessage = "El balance NO es valido")]
    public double Balance {get; set;}

}