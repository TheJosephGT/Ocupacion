using System.ComponentModel.DataAnnotations;

public class Ocupaciones{
    [Key]
        public int OcupacionID { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public string? Descripcion { get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage ="Ingrese un sueldo valido")]
        public double Salario { get; set; }


}
