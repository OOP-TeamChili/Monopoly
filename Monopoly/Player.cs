namespace Monopoly
{
    using System;
    using System.Collections.Generic;

    using Monopoly.Cards;
    using Monopoly.Interfaces;

    public class Player : Element
    {
        //this is forchecking the turns 
        bool IsGameOver;
        public int PlayerNumber { get; set; }
        //
        private int bankroll;
        public string Name { get; set; }
        //private List<purchasableSpaces> ownedSpaces = new List<purchasableSpaces>();
        private int totalValue;
        private List<ISavable> cards;
        
        private int position;
        private List<PurchasableSpace> listOfProperties;
      

        public Player()
        {
            throw new NotImplementedException();
        }

        public Player(int playerNumber, string playerName, int startPos = 0, int startBankroll = 1500)
        {
            this.PlayerNumber = playerNumber;
            this.Name = playerName;
            this.cards = new List<ISavable>();
            this.Position = startPos;
            this.Bankroll = startBankroll;
            this.listOfProperties = new List<PurchasableSpace>();
        }

        public int Bankroll
        {
            get
            {
                return this.bankroll;
            }
            set
            {
                this.bankroll = value;
            }
        }
        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public int TotalValue
        {
            get
            {
                return this.totalValue;
            }
            set
            {
            }
        }

        public List<ISavable> Cards
        {
            get
            {
                return new List<ISavable>(cards);
            }
        }

        public List<PurchasableSpace> ListOfProperties
        {
            get
            {
                return new List<PurchasableSpace>(this.listOfProperties);
            }
        }
        //TODO: token 

        //method to take and keep the card for later.
        public void KeepCard(ISavable card)
        {
            this.cards.Add(card);
        }

        //Method to move the player when takes a chance card.
        public void CardMove(ChanceCard card)
        {
            //player.position += this.SquaresToMove
            throw new NotImplementedException();
        }

        //Method to pay or get paid when picks up a card.
        public void CardPay(ChanceCard card)
        {
            if (card.CardType == CardType.BadLuckCard)
            {
                this.Bankroll = this.Bankroll - (int)card.Cash;
            }
            else if (card.CardType == CardType.LuckyCard)
            {
                this.Bankroll = this.Bankroll + (int)card.Cash;
            }
        }

        //Method to mvoe the player to a specific space by card.
        public void GoToSpace(ChanceCard card)
        {
            //if space owned - pay the player
            //if not - decide whether to buy or not.
            CardPay(card); // this method stays because there are cards that move the player and the player pays or get paid by the card.
        }

        public void AddCash(int moneyToAdd)
        {
            this.Bankroll = this.Bankroll + moneyToAdd;
        }

        public void AddSpace(PurchasableSpace  boughtProperty)
        {
            listOfProperties.Add(boughtProperty);
        }

        public void RemoveCash(int moneyToRemove)
        {
            this.Bankroll = this.Bankroll - moneyToRemove;
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
            
            
        }
    }
}
