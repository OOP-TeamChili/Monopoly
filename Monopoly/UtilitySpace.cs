namespace Monopoly
{
    using MonopolyConsoleClient.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class UtilitySpace : PurchasableSpace, IPurchasable
    {
        public UtilitySpace(string currentName, decimal currentPrice, decimal currentMortgageValue, decimal currentRent) :         
            base(currentName, currentPrice, currentMortgageValue, currentRent)
        {           
        }  
    }
}
