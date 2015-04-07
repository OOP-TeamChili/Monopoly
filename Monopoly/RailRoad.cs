using MonopolyConsoleClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class RailRoad : PurchasableSpace, IPurchasable
    {
        public RailRoad(string currentName, decimal currentPrice, decimal currentMortgageValue, decimal currentRent) :         
            base(currentName, currentPrice, currentMortgageValue, currentRent)
        {           
        }       
    

    }
}
