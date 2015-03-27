using System;
using System.Linq;
using ConsoleStuffs;
using System.Threading;

namespace Monopoly
{
    public class Dices : IRotateble
    {
        private static Random rand = new Random();
        private RandomGenerator random = new RandomGenerator(rand);

        private string dicesValues { get; set; }

        

        private int cursorRow;
        private int cursorCol;

        private int SecondDiceCursorRow;
        private int SecondDiceCursorCol;

        public int FirstDiceValue { get; private set; }
        public int SecondDiceValue { get; private set; }

        private string[][,] dices;
        
        //Sets default random Value of the dice
        public Dices(int cursorCol,int cursorRow)
        {
            this.cursorRow = cursorCol;
            this.cursorCol = cursorRow;
            this.SecondDiceCursorCol = cursorCol;
            this.SecondDiceCursorRow = cursorRow + 12;

            dices = new string[6][,];
            dices[0] = SplashScreen.MakeDices(@"../../Files/Dices/DiceOne.txt", dices[0]);
            dices[1] = SplashScreen.MakeDices(@"../../Files/Dices/DiceTwo.txt", dices[1]);
            dices[2] = SplashScreen.MakeDices(@"../../Files/Dices/DiceThree.txt", dices[2]);
            dices[3] = SplashScreen.MakeDices(@"../../Files/Dices/DiceFour.txt", dices[3]);
            dices[4] = SplashScreen.MakeDices(@"../../Files/Dices/DiceFive.txt", dices[4]);
            dices[5] = SplashScreen.MakeDices(@"../../Files/Dices/DiceSix.txt", dices[5]);
            this.FirstDiceValue = random.Next(0,6);
            this.SecondDiceValue = random.Next(0, 6);
        }

        //Rotate the dice runtime
        private void RotateDice(int start, int end)
        {
            this.FirstDiceValue = random.Next(start, end);
            this.SecondDiceValue = random.Next(start, end);
        }

        // This will visualize the dice till rotations
        public void ThrowDices()
        {
            RotateDice(2,8);

            int defaultCol = this.cursorRow;
            int secondDiceDefaultCol = this.SecondDiceCursorCol;
            //int defaultRow = this.CursorRow;

            int cycleRotations = Math.Max(FirstDiceValue,SecondDiceValue);

            //gets random dice everyTime the cycle rotates and it rotates Value times /which is random also/
            for (int i = 0; i < cycleRotations; i++)
            {
                RotateDice(0,6);

                for (int row = 0; row < dices[FirstDiceValue].GetLength(0); row++)
                {
                    Console.SetCursorPosition(this.cursorCol, this.cursorRow);
                    for (int col = 0; col < dices[FirstDiceValue].GetLength(1); col++)
                    {
                        Console.Write(dices[FirstDiceValue][row, col]);
                    }
              
                    Console.SetCursorPosition(this.SecondDiceCursorRow,this.SecondDiceCursorCol);
                    for (int col = 0; col < dices[FirstDiceValue].GetLength(1); col++)
                    {
                        Console.Write(dices[SecondDiceValue][row, col]);
                    }
                    SecondDiceCursorCol++;
                    this.cursorRow++;
                    Console.SetCursorPosition(this.cursorCol, this.cursorRow);
                }
                this.cursorRow = defaultCol;
                this.SecondDiceCursorCol = secondDiceDefaultCol;

                Thread.Sleep(930);
            }
            Console.WriteLine();
            this.dicesValues = String.Format("{0}{1}", SecondDiceValue + 1, FirstDiceValue + 1);
            this.FirstDiceValue = int.Parse(this.dicesValues[1].ToString());
            this.SecondDiceValue = int.Parse(this.dicesValues[0].ToString());
        }


    }
}
