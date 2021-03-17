using System.ComponentModel.DataAnnotations;

namespace SpaceWeightConverter.Models
{
    public class Calculation
    {
        public Calculation()
        {
            this.Result = 0;         
        }

        [Key]
        public int ID { get; set; }
        public string SpaceObjectName { get; set; }
        public decimal Weight { get; set; }
        public string Operator { get; set; }
        public decimal Result { get; set; }
        public decimal CoefficientValue { get; set; }
       
        public void CalculateResult()
        {
            this.Result = this.Weight * this.CoefficientValue;
        }
    }
}


