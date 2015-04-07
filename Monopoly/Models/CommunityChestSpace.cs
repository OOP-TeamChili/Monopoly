﻿using Monopoly;
using Monopoly.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CommunityChestSpace : Space
    {
        public ChanceCard ChanceCardPull()
        {
            Queue<ChanceCard> communityCards = CardInitializer.InitializeChanceList();
            ChanceCard topCard = communityCards.Dequeue();
            return topCard;
        }
    }
}
