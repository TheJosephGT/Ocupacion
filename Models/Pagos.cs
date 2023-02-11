

using System.ComponentModel.DataAnnotations;

public class Pagos{

    [Key]

    public int PagoId {get; set;}
    [Required(ErrorMessage = "El campo pagoID es obligatorio.")]

    public string? Fecha {get; set;}

    public int PersonaId {get;set;}

    public string? Concepto {get;set;}

    public double Monto {get;set;}
}