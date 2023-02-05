

using System.ComponentModel.DataAnnotations;

public class PagosDetalle{

    [Key]

    public int Id {get; set;}
    [Required(ErrorMessage = "El campo pagoId es obligatorio.")]

    public int PagoId {get; set;}

    public string? PrestamoId {get; set;}

    public int? ValorPagado {get;set;}
}