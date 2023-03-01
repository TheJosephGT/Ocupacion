using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pagos{

    [Key]
    public int PagoId {get; set;}

    [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
    public DateTime Fecha {get; set;}
    public int PersonaId {get;set;}

    [Required(ErrorMessage = "El campo Concepto es obligatorio.")]
    public string? Concepto {get;set;}

    [Range(0.01, double.MaxValue, ErrorMessage = "Valor invalido para monto")]
    public double Monto {get;set;}

    [ForeignKey("PagoId")]
    public virtual List<PagosDetalle> PagosDetalle {get;set;} = new List<PagosDetalle> ();

    public Pagos(){
        PagoId = 0;
        Fecha = DateTime.Now;

        PagosDetalle = new List<PagosDetalle>();
    }
}