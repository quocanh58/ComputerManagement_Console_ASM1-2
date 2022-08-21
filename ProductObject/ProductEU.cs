using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductObject
{
    public class ProductEU : Product
    {
        public double tax { get; set; }

        public override double CalculatorCost()
        {
            return (ProductQuatity * ProductPrice) + ((1 + tax) / 100);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine(" >> Cost of product EU: " + CalculatorCost());
        }
    }
}
