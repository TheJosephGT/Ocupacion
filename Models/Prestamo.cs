using System.ComponentModel.DataAnnotations;

//Campos: PrestamoId,Fecha,Vence, PersonaId,Concepto,Monto,Balance;
public class Prestamo{
    [Key]
    public int PrestamoId {get; set;}
    [Required(ErrorMessage = "El campo PrestamoId es requerido")]

    public string? Fecha {get;set;}

    public string? Vence {get;set;}

    public int? PersonaId {get; set;}

    public string? Concepto {get; set;}

    public int? monto {get; set;}

    public int? balance {get; set;}

}