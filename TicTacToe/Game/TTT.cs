namespace TicTacToe.Game
{
    public class TTT
    {
        private int _currentPlayerIndex = 0;
        private readonly List<string> _players;
        private readonly List<string> _symbols = new List<string> { "X", "O" };
        private bool _isGameOver = false;
        private string? _winner = null;

        private readonly List<List<string>> _board = new List<List<string>>
        {
            new List<string> { " ", " ", " " },
            new List<string> { " ", " ", " " },
            new List<string> { " ", " ", " " }
        };

        public TTT(List<string> players)
        {
            _players = players;
        }

        private bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3 && _board[row][col] == " ";
        }

        private bool CheckWin(int row, int col)
        {
            string symbol = _board[row][col];

            if (_board[row].All(cell => cell == symbol)) return true;
            if (_board.All(r => r[col] == symbol)) return true;
            if (row == col && Enumerable.Range(0, 3).All(i => _board[i][i] == symbol)) return true;
            if (row + col == 2 && Enumerable.Range(0, 3).All(i => _board[i][2 - i] == symbol)) return true;

            return false;
        }

        private bool IsBoardFull()
        {
            return !_board.Any(row => row.Any(cell => cell == " "));
        }

        public bool Play(int row, int col)
        {
            if (_isGameOver || !IsValidMove(row, col)) return false;

            _board[row][col] = _symbols[_currentPlayerIndex];

            if (CheckWin(row, col))
            {
                _isGameOver = true;
                _winner = _players[_currentPlayerIndex];
            }
            else if (IsBoardFull())
            {
                _isGameOver = true;
                _winner = "Draw";
            }

            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
            return true;
        }

        public string CurrentPlayer()
        {
            return _players[_currentPlayerIndex];
        }

        public List<List<string>> GetBoard() => _board;

        public bool IsGameOver() => _isGameOver;

        public string GetWinner()
        {
            if (_winner != null) return _winner;
            return "Winner not determined yet";
        }
    }
}
