namespace Monopoly.Interfaces
{
    public interface IDice
    {
        int FirstDiceValue { get; }
        int SecondDiceValue { get;  }
        void Roll();
    }
}
