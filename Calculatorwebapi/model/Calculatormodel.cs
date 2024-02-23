using System.ComponentModel.DataAnnotations;

namespace Calculatorwebapi.model
{
    public class Calculatormodel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Num1 { get; set; }

        [Required]
        public double Num2 { get; set; }

        [Required]
        public string MathOption { get; set; }
    }
}
