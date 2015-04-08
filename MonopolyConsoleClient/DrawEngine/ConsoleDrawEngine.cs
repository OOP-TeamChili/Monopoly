namespace MonopolyConsoleClient.DrawEngine
{
    using System;
    using System.IO;
    using System.Threading;

    using Monopoly.Interfaces;
    using Monopoly.Players;

    internal class ConsoleDrawEngine : IDrawingEngine
    {
        private string[][,] dices;

        public ConsoleDrawEngine()
        {
            dices = new string[6][,];
            dices[0] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceOne.txt", dices[0]);
            dices[1] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceTwo.txt", dices[1]);
            dices[2] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceThree.txt", dices[2]);
            dices[3] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceFour.txt", dices[3]);
            dices[4] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceFive.txt", dices[4]);
            dices[5] = SplashScreen.MakeDices(@"../../../Monopoly/Files/Dices/DiceSix.txt", dices[5]);
        }

        public void DrawText(int x, int y, string text)
        {
            this.PrintTextAtPosition(x, y, text);
        }

        public void DrawPlayer(Player player, int oldX, int oldY)
        {
            this.PrintTextAtPosition(oldX, oldY, " ");
            this.PrintTextAtPosition(player.PosX, player.PosY, player.Symbol.ToString());
        }

        public void DrawField()
        {
            StreamReader reader = new StreamReader(@"../../../Monopoly/Files/field.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                int row = 0;
                while (currentLine != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        this.DrawText(0, row, currentLine);
                    }
                    row++;
                    currentLine = reader.ReadLine();
                }
            }
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DrawDices(int firstValue, int secondValue)
        {
            int cycleRotations = Math.Max(firstValue, secondValue);
            int cursorCol = 5;
            int cursorRow = 0;
            int defaultCol = cursorRow;
            int secondDiceCursorCol = cursorCol;
            int secondDiceCursorRow = cursorRow + 12;
            int secondDiceDefaultCol = secondDiceCursorCol;

            for (int i = 0; i < cycleRotations; i++)
            {
                for (int row = 0; row < dices[firstValue].GetLength(0); row++)
                {
                    Console.SetCursorPosition(cursorCol, cursorRow);
                    for (int col = 0; col < dices[firstValue].GetLength(1); col++)
                    {
                        Console.Write(dices[firstValue][row, col]);
                    }
              
                    Console.SetCursorPosition(secondDiceCursorRow, secondDiceCursorCol);
                    for (int col = 0; col < dices[firstValue].GetLength(1); col++)
                    {
                        Console.Write(dices[secondValue][row, col]);
                    }

                    secondDiceCursorCol++;
                    cursorRow++;
                    Console.SetCursorPosition(cursorCol, cursorRow);
                }
                
                cursorRow = defaultCol;
                secondDiceCursorCol = secondDiceDefaultCol;

                Thread.Sleep(930);
                this.ClearScreen();
            }

            Console.WriteLine();
        }

        private void PrintTextAtPosition(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
