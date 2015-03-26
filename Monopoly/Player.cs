using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Player:Element
    {
        //this is forchecking the turns 
        bool IsGameOver;
        public int PlayerNumber { get; set; }
        //
        private int bankroll;
        public string Name { get; set; }
        //private List<purchasableSpaces> ownedSpaces = new List<purchasableSpaces>();
        private int totalValue;

        public Player()
        {
            throw new NotImplementedException();
        }

        public Player(int playerNumber, string playerName)
        {
            this.PlayerNumber = playerNumber;
            this.Name = playerName;
        }

        public int Bankroll
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
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
        //TODO: token 

        public void AddCash()
        {
            throw new System.NotImplementedException();
        }

        public void AddSpace()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCash()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
            
            
        }
    }
}
