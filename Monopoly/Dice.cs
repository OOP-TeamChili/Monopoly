using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class Dice
    {
        private int valueDice;
       
        //Emil don't need of constructor for Dice class
        //private Random rand= new Random();

        //public Dice(int firstDice,int secondDice)
        //{
        //
        //    
        //}

        public int ValueDice
        {
            get
            {
                return this.valueDice;
            }
            set
            {
                valueDice = value;
            }
        }

       
        public int totalValue
        {
            get
            {
                throw new System.NotImplementedException();
            }
            private set
            {
            }
        }

        public void RollDice()
        {
            throw new System.NotImplementedException();
        }


    }
}
