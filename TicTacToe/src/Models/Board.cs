using TicTacToe.src.Enums;

namespace TicTacToe.src.Models
{
    public class Board
    {
        private int _size;
        private List<List<Symbol>> _grid;

        public Board(int size = 3)
        {
            _size = size;
            _grid = ResetGrid();
        }

        private bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < _size && col >= 0 && col < _size;
        }

        public bool MarkSymbol(int row, int col, Symbol symbol)
        {
            if (!IsValidPosition(row, col) || _grid[row][col] != Symbol.Empty)
                return false;

            _grid[row][col] = symbol;
            return true;
        }

        public bool IsBoardFull()
        {
            return !_grid.Any(row => row.Any(col => col == Symbol.Empty));
        }

        public void ResetBoard()
        {
            _grid = ResetGrid();
        }

        private List<List<Symbol>> ResetGrid()
        {
            List<List<Symbol>> emptyGrid = new List<List<Symbol>>();

            for (int row = 0; row < _size; row++)
            {
                emptyGrid.Add(Enumerable.Repeat(Symbol.Empty, _size).ToList());
            }

            return emptyGrid;
        }

        public bool HasWinner(int row, int col, Symbol symbol)
        {
            if (_grid[row].All(cell => cell == symbol))
                return true;

            if (Enumerable.Range(0, _size).All(r => _grid[r][col] == symbol))
                return true;

            if (row == col && Enumerable.Range(0, _size).All(i => _grid[i][i] == symbol))
                return true;

            if (row + col == _size - 1 && Enumerable.Range(0, _size).All(i => _grid[i][_size - 1 - i] == symbol))
                return true;

            return false;
        }
    }
}
