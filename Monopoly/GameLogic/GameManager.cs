using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameLogic
{
    class GameManager
    {
        const int DiceMinValue = 1;
        const int DiceMaxValue = 6;
        const int PositionsOnBoard = 42;
        const int CycleCash = 200;
        public static void Game(Player[] playersArray)
        {
            List<Space> listOfSpaces = new List<Space>();
            
            //PROPERTIES JUST FOR EXAMPLE
            for (int i = 0; i < 42; i++)
            {
                string propertyName = "Property" + i;
                PropertySpace newProperty = new PropertySpace(propertyName, i * 10, i * 10 / 2, i);
                listOfSpaces.Add(newProperty);
            }
            Console.Clear();
            int currentPlayer = 0;              
            while (true)
            {
                Dice dice1 = new Dice();
                Dice dice2 = new Dice();
                Random rand1=new Random();  
                Random rand2=new Random();  
                dice1.ValueDice = rand1.Next(DiceMinValue, DiceMaxValue + 1);
                dice2.ValueDice = rand2.Next(DiceMinValue, DiceMaxValue + 1);                
                var player = playersArray[currentPlayer];
                player.Position = player.Position + dice1.ValueDice + dice2.ValueDice;
                var currentProperty=listOfSpaces[player.Position];
                if (player.Position > PositionsOnBoard-1)
                {
                    player.Position = player.Position - PositionsOnBoard;
                    player.AddCash(CycleCash);
                }
                if (!player.ListOfProperties.Contains(listOfSpaces[player.Position]))
                {
                    for (int i=0;i<playersArray.Length;i++)
                    {
                        var otherPlayer=playersArray[i];
                        if (i != currentPlayer && otherPlayer.ListOfProperties.Contains(listOfSpaces[player.Position]))
                        {
                            //TO DO: Check for hotel
                            //TO DO: Check for house
                           // player.RemoveCash(currentProperty.)
                        }
                    }
                }

            }
        }
    }
}
