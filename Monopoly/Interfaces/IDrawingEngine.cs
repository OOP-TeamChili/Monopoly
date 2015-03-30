namespace Monopoly.Interfaces
{
    using Monopoly.Players;

    public interface IDrawingEngine
    {
        void DrawText(int x, int y, string text);

        void DrawPlayer(Player player);
    }
}
