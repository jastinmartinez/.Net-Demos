using System;
namespace Lab01.Models
{
    public class AdditionModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public double AdditionResult { get => FirstNumber + SecondNumber;  }
    }
}
