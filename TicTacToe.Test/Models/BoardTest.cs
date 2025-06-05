namespace TicTacToe.Test.Models;

using TicTacToe.Enums;
using TicTacToe.Models;

public class BoardTests
{
    [Fact]
    public void Should_Initialize_EmptyGrid()
    {
        Board board = new Board(3);

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Assert.True(board.MarkSymbol(row, col, Symbol.X));
            }
        }

        Assert.True(board.IsBoardFull());
    }

    [Fact]
    public void Should_Mark_Valid_Position()
    {
        Board board = new Board();

        bool result = board.MarkSymbol(1, 1, Symbol.X);

        Assert.True(result);
        board.MarkSymbol(0, 0, Symbol.O);
        Assert.False(board.MarkSymbol(0, 0, Symbol.X));
    }

    [Fact]
    public void Should_Not_Mark_Invalid_Position()
    {
        Board board = new Board();

        Assert.False(board.MarkSymbol(-1, 0, Symbol.X));
        Assert.False(board.MarkSymbol(0, -1, Symbol.X));
        Assert.False(board.MarkSymbol(3, 0, Symbol.X));
        Assert.False(board.MarkSymbol(0, 3, Symbol.X));
    }

    [Fact]
    public void IsBoardFull_WhenEmpty_ReturnsFalse()
    {
        Board board = new Board();

        Assert.False(board.IsBoardFull());
    }

    [Fact]
    public void IsBoardFull_WhenFull_ReturnsTrue()
    {
        Board board = new Board();

        for (int row = 0; row < 3; row++)
        for (int col = 0; col < 3; col++)
            board.MarkSymbol(row, col, Symbol.O);

        Assert.True(board.IsBoardFull());
    }

    [Fact]
    public void ResetBoard_ClearsGrid()
    {
        Board board = new Board();

        board.MarkSymbol(0, 0, Symbol.X);
        board.MarkSymbol(1, 1, Symbol.O);

        board.ResetBoard();

        Assert.True(board.MarkSymbol(0, 0, Symbol.X));
        Assert.True(board.MarkSymbol(1, 1, Symbol.O));
    }

    [Fact]
    public void HasWinner_ShouldReturnTrue_WhenRowIsComplete()
    {
        Board board = new Board();

        for (int col = 0; col < 3; col++)
        {
            board.MarkSymbol(1, col, Symbol.X);
        }

        bool hasWinner = board.HasWinner(1, 2, Symbol.X);
        Assert.True(hasWinner);
    }

    [Fact]
    public void HasWinner_ShouldReturnTrue_WhenColumnIsComplete()
    {
        Board board = new Board();

        for (int row = 0; row < 3; row++)
        {
            board.MarkSymbol(row, 0, Symbol.O);
        }

        bool hasWinner = board.HasWinner(2, 0, Symbol.O);
        Assert.True(hasWinner);
    }

    [Fact]
    public void HasWinner_ShouldReturnTrue_WhenMainDiagonalIsComplete()
    {
        Board board = new Board();

        for (int i = 0; i < 3; i++)
        {
            board.MarkSymbol(i, i, Symbol.X);
        }

        bool hasWinner = board.HasWinner(2, 2, Symbol.X);
        Assert.True(hasWinner);
    }

    [Fact]
    public void HasWinner_ShouldReturnTrue_WhenAntiDiagonalIsComplete()
    {
        Board board = new Board();

        for (int i = 0; i < 3; i++)
        {
            board.MarkSymbol(i, 2 - i, Symbol.O);
        }

        bool hasWinner = board.HasWinner(2, 0, Symbol.O);
        Assert.True(hasWinner);
    }

    [Fact]
    public void HasWinner_ShouldReturnFalse_WhenNoWinner()
    {
        Board board = new Board();

        board.MarkSymbol(0, 0, Symbol.X);
        board.MarkSymbol(0, 1, Symbol.O);
        board.MarkSymbol(1, 1, Symbol.X);
        board.MarkSymbol(2, 1, Symbol.O);

        bool hasWinner = board.HasWinner(2, 1, Symbol.O);
        Assert.False(hasWinner);
    }
}