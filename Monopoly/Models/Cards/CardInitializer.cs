namespace Monopoly.Cards
{
    using System;
    using System.Collections.Generic;

    public class CardInitializer
    {

        private static List<ChanceCard> community = new List<ChanceCard>()
        {
          
            new GoodLuckCard("Bank Error In Your Favor – Collect $200", CardType.LuckyCard, 200),
            new GoodLuckCard("Doctor's Fee – Pay $50 ", CardType.BadLuckCard, 50),
            new SpaceCard("Advance to Vine Street", 19, CardType.LuckyCard),          
            new GoodLuckCard("Grand Opera Opening – Collect $50", CardType.LuckyCard, 50),
            new GoodLuckCard("Income Tax refund – Collect $20 ", CardType.LuckyCard, 20),
            new GoodLuckCard("Life Insurance Matures – Collect $100 ", CardType.LuckyCard, 100),
            new GoodLuckCard("Pay Hospital $100 ", CardType.BadLuckCard, 100),           
        };

        private static List<ChanceCard> chanceList = new List<ChanceCard>()
        {           
            new GoodLuckCard("Your Building And Loan Matures – Collect $150", CardType.LuckyCard, 150),
            new SpaceCard("Advance to Northumber Land Ave", 14, CardType.Neutral), // space to be replaced with Illinois Ave           
            new SpaceCard("Advance to Pall Mall", 11, CardType.Neutral),         
            new MoveCard("Go back 3 spaces", CardType.Neutral, 3),                     
       };

        public static Queue<ChanceCard> InitializeCommunityList()
        {
            community.Shuffle<ChanceCard>();
            return new Queue<ChanceCard>(community);
        }

        public static Queue<ChanceCard> InitializeChanceList()
        {
            chanceList.Shuffle<ChanceCard>();
            return new Queue<ChanceCard>(chanceList);
        }

    }
}
