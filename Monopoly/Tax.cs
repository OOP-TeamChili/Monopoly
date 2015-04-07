namespace MonopolyConsoleClient
{
    using Monopoly;
    using Monopoly.Cards;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Tax: Space
    {
        public Tax(int taxToPay)
        {
            this.TaxToPay = taxToPay;
        }
        public int TaxToPay { get; set; }
    }
}
