using System.ComponentModel.DataAnnotations;

public class Ocupaciones{
    [Key]
        public int OcupacionId { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string? Descripcion { get; set; }
        
        [Range(1000, double.MaxValue, ErrorMessage ="Ingrese un sueldo valido")]
        public double Salario { get; set; }


}
