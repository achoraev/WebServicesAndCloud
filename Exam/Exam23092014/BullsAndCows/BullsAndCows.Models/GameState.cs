namespace BullsAndCows.Models
{
    public enum GameState
    {
        RedInTurn = 0,
        BlueInTurn = 1,
        WaitingForOpponent = 2,
        RedWonGame = 3,
        BlueWonGame = 4,
        GameDraw = 5
    }
}