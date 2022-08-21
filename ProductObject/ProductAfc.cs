using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductObject
{
    public class ProductAfc : Product
    {
        public double cost { get; set; }
        public override double CalculatorCost()
        {
            return (ProductQuatity * ProductPrice) + cost;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine(" >> Cost of product AFC: " + CalculatorCost());
        }
    }
}
