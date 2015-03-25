using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class PropertySpace:purchasableSpace
    {
        public PropertySpace(string currentName, decimal currentPrice, decimal currentMortgageValue, decimal currentRent)
             :base(currentName,currentPrice,currentMortgageValue,currentRent)
        {                  
        }
    }
}
