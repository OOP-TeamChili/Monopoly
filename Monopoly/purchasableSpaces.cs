using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
   public abstract class purchasableSpace:Space
    {
        private bool mortgaged;
        private int mortgageValue;
        private int price;
        private Player owner = new Player();

    }
}
