namespace MonopolyConsoleClient.DrawEngine
{
    using System;

    using Monopoly.Interfaces;
    using Monopoly.Players;

    internal class ConsoleDrawEngine : IDrawingEngine
    {
        public void DrawText(int x, int y, string text)
        {
            this.PrintTextAtPosition(x, y, text);
        }

        public void DrawPlayer(Player player)
        {
            throw new System.NotImplementedException();
        }

        private void PrintTextAtPosition(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
