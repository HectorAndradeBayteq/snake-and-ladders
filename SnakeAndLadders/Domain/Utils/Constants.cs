
namespace Domain.Utils
{
    public enum SquareType
    {
        Normal = 0,
        Snake = 1,
        Ladder = 2,
    }

    public enum PlayerCommand
    {
        GetState = 0,
        RollDice = 1,
        Exit = 2,
        Unkwow = 3
    }

    public enum GameStatusType
    {
        State = 0,
        NoIsPlayerTurn = 1,
        PlayerHasWon = 2,
        TurnOver = 3
    }
}
