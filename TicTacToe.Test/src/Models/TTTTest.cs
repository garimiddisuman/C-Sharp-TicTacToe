using TicTacToe.src.Enums;
using TicTacToe.src.Models;

namespace TicTacToe.Test.src.Models
{
    public class TTTTests
    {
        [Fact]
        public void Should_InitializeWithPlayer1Turn()
        {
            List<string> players = new List<string> { "Player-1", "Player-2" };
            TTT game = new TTT(players);

            Assert.Equal(Symbol.X, game.CurrentSymbol());
            Assert.Equal("Player-1", game.CurrentPlayer());
        }

        [Fact]
        public void Should_Mark_And_Change_Player()
        {
            List<string> players = new List<string> { "Player-1", "Player-2" };
            TTT game = new TTT(players);

            bool firstMove = game.Mark(0, 0);
            Assert.True(firstMove);
            Assert.Equal(Symbol.O, game.CurrentSymbol());
            Assert.Equal("Player-2", game.CurrentPlayer());
        }

        [Fact]
        public void Should_Not_Allow_Marking_Twice()
        {
            List<string> players = new List<string> { "Player-1", "Player-2" };
            TTT game = new TTT(players);

            game.Mark(0, 0);
            bool result = game.Mark(0, 0);

            Assert.False(result);
        }

        [Fact]
        public void Should_Declare_Winner_Correctly()
        {
            List<string> players = new List<string> { "Player-1", "Player-2" };
            TTT game = new TTT(players);

            game.Mark(0, 0); // X
            game.Mark(1, 0); // O
            game.Mark(0, 1); // X
            game.Mark(1, 1); // O
            game.Mark(0, 2); // X wins

            string winner = game.GetWinner();

            Assert.Equal(GameState.Won, game.GetGameState());
            Assert.Equal("Player-1", winner);
        }

        [Fact]
        public void Should_Declare_Draw_Correctly()
        {
            List<string> players = new List<string> { "Player-1", "Player-2" };
            TTT game = new TTT(players);

            game.Mark(0, 0); // X
            game.Mark(0, 1); // O
            game.Mark(0, 2); // X
            game.Mark(1, 1); // O
            game.Mark(1, 0); // X
            game.Mark(1, 2); // O
            game.Mark(2, 1); // X
            game.Mark(2, 0); // O
            game.Mark(2, 2); // X

            string winner = game.GetWinner();

            Assert.Equal(GameState.Draw, game.GetGameState());
            Assert.Equal("Winner not determined yet", winner);
        }
    }
}
