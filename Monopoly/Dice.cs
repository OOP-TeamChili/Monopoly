namespace Monopoly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dice
    {
        private int valueDice;
        private Random rand;

        public Dice()
        {
            this.valueDice = 0;
            rand = new Random();
        }

        public int ValueDice
        {
            get
            {
                return this.valueDice;
            }
            set
            {
                this.valueDice = value;
            }
        }
        public void RollDice()
        {
            this.valueDice = rand.Next(1, 7);
        }
    }
}
