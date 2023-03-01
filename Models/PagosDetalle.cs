

using System.ComponentModel.DataAnnotations;

public class PagosDetalle{

    [Key]

    public int Id {get; set;}
    public int PagoId {get; set;}
    public int PrestamoId {get; set;}

    [Range(1, double.MaxValue, ErrorMessage = "El ValorPagado no es valido.")]
    public double ValorPagado {get;set;}
}