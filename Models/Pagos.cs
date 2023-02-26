using System.ComponentModel.DataAnnotations;

public class Pagos{

    [Key]
    public int PagoId {get; set;}

    public DateTime Fecha {get; set;}

    [Required(ErrorMessage = "El campo PersonaId es obligatorio.")]
    public int PersonaId {get;set;}

    [Required(ErrorMessage = "El campo Concepto es obligatorio.")]
    public string? Concepto {get;set;}

    [Range(0.01, double.MaxValue, ErrorMessage = "Valor invalido para monto")]
    public double Monto {get;set;}
}