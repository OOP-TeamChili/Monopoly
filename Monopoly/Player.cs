using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Player : Element
    {
        private int bankroll;
        private string name;
        private int position;
        private List<purchasableSpace> listOfProperties;
        public int PlayerNumber { get; set; }


        //private List<purchasableSpaces> ownedSpaces = new List<purchasableSpaces>();
        private int totalValue;

        public Player(int playerNumber,string inputName, int startPos = 0, int startBankroll = 1500)
        {
            this.PlayerNumber = playerNumber;
            this.Name = inputName;
            this.Position = startPos;
            this.Bankroll = startBankroll;
            this.listOfProperties=new List<purchasableSpace>();
        }

        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
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

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new NullReferenceException("Invaid name");
                }
                this.name = value;
            }
        }

        public int TotalValue
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<purchasableSpace> ListOfProperties
        {
            get
            {
                return new List<purchasableSpace>(this.listOfProperties);
            }
        }

        //TODO: token 

        public void AddCash(int sumToAdd)
        {
            this.Bankroll = this.Bankroll + sumToAdd;
        }
        public void RemoveCash(int sumToRemove)
        {
            this.Bankroll = this.Bankroll - sumToRemove;
        }

        public void AddSpace(purchasableSpace boughtProperty)
        {
            listOfProperties.Add(boughtProperty);
        }

       

        public override string ToString()
        {
            throw new System.NotImplementedException();

        }
    }
}
