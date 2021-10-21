using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicattion.Core
{
    public static class Calculator
    {
        public static decimal Calcule(int quantity, decimal price, string type)
        {
            int promotionQtde = 0;
            int rest = 0;
            decimal total = 0;

            switch (type)
            {
                case "3x40":
                    promotionQtde = quantity / 3;
                    rest = quantity % 3;
                    total = (rest * price) + (promotionQtde * 40);
                    break;

                case "2x-25":
                    promotionQtde = quantity / 2;
                    rest = quantity % 2;
                    decimal totalToCalcule = promotionQtde * price;

                    total = (totalToCalcule - totalToCalcule * .25M) + (rest * price);
                    break;

                default:
                    total = quantity * price;
                    break;
            }

            if (total == 0)
            {
                throw new Exception("Error on promotion apply.");
            }

            return total;
        }
    }
}
