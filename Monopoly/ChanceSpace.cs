using Monopoly;
using Monopoly.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ChanceSpace : Space
    {
        public ChanceCard ChanceCardPull()
        {
            Queue<ChanceCard> chanceCards = CardInitializer.InitializeChanceList();
            ChanceCard topCard = chanceCards.Dequeue();
            return topCard;
        }
    }
}
