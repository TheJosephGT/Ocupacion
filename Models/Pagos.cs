

using System.ComponentModel.DataAnnotations;

public class Pagos : PagosDetalle{

    [Key]

    public int PagoId {get; set;}
    [Required(ErrorMessage = "El campo pagoID es obligatorio.")]

    public string? Fecha {get; set;}

    public int? PersonaId {get;set;}

    public string? Concepto {get;set;}

    public string? Monto {get;set;}
}