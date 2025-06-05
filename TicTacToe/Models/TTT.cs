namespace TicTacToe.Models;

using TicTacToe.Enums;

public class TTT
{
    private readonly List<string> _players;
    private int _currentPlayerIndex;
    private GameState _gameState;
    private Board _board;

    public TTT(List<string> players)
    {
        _players = players;
        _board = new Board();
        _currentPlayerIndex = 0;
        _gameState = GameState.InProgress;
    }

    public bool Mark(int row, int col)
    {
        Symbol symbol = GetCurrentSymbol();

        if (!_board.MarkSymbol(row, col, symbol))
            return false;

        _gameState = DetermineGameState(row, col, symbol);

        if (_gameState == GameState.InProgress)
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;

        return true;
    }

    private GameState DetermineGameState(int row, int col, Symbol symbol)
    {
        if (_board.HasWinner(row, col, symbol))
            return GameState.Won;

        if (_board.IsBoardFull())
            return GameState.Draw;

        return GameState.InProgress;
    }

    public string GetWinner()
    {
        if (_gameState == GameState.Won) return GetCurrentPlayer();

        return "Winner not determined yet";
    }

    public string GetCurrentPlayer() => _players[_currentPlayerIndex];
    public GameState GetGameState() => _gameState;
    public Symbol GetCurrentSymbol() => _currentPlayerIndex == 0 ? Symbol.X : Symbol.O;
}
