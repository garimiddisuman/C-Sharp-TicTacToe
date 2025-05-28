using TicTacToe.Game;

namespace TicTacToe.Test.Game
{
    public class TicTacToeTests
    {
        [Fact]
        public void ShouldAllowValidMove()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });
            bool result = game.Play(0, 0);
            Assert.True(result);
            Assert.Equal(" ", game.GetBoard()[0][1]);
        }

        [Fact]
        public void ShouldRejectInvalidMove()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });
            game.Play(0, 0);
            bool result = game.Play(0, 0);
            Assert.False(result);
        }

        [Fact]
        public void ShouldWinOnRow()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });

            game.Play(0, 0); // player-1
            game.Play(1, 0); // player-2
            game.Play(0, 1); // player-1
            game.Play(1, 1); // player-2
            game.Play(0, 2); // player-1 - wins

            Assert.True(game.IsGameOver());
            Assert.Equal("player-1", game.GetWinner());
        }

        [Fact]
        public void ShouldWinOnColumn()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });

            game.Play(0, 0); // player-1
            game.Play(0, 1); // player-2
            game.Play(1, 0); // player-1
            game.Play(1, 1); // player-2
            game.Play(2, 0); // player-1 - wins

            Assert.True(game.IsGameOver());
            Assert.Equal("player-1", game.GetWinner());
        }

        [Fact]
        public void ShouldWinOnDiagonal()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });

            game.Play(0, 0); // player-1
            game.Play(0, 1); // player-2
            game.Play(1, 1); // player-1
            game.Play(0, 2); // player-2
            game.Play(2, 2); // player-1 - wins

            Assert.True(game.IsGameOver());
            Assert.Equal("player-1", game.GetWinner());
        }

                [Fact]
        public void ShouldWinOnAntiDiagonal()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });

            game.Play(2, 0); // player-1
            game.Play(0, 1); // player-2
            game.Play(1, 1); // player-1
            game.Play(1, 2); // player-2
            game.Play(0, 2); // player-1 - wins

            Assert.True(game.IsGameOver());
            Assert.Equal("player-1", game.GetWinner());
        }

        [Fact]
        public void ShouldDetectDraw()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });

            game.Play(0, 0); // player-1
            game.Play(0, 1); // player-2
            game.Play(0, 2); // player-1
            game.Play(1, 1); // player-2
            game.Play(1, 0); // player-1
            game.Play(1, 2); // player-2
            game.Play(2, 1); // player-1
            game.Play(2, 0); // player-2
            game.Play(2, 2); // player-1

            Assert.True(game.IsGameOver());
        }

        [Fact]
        public void ShouldReturnCurrentPlayerCorrectly()
        {
            TTT game = new TTT(new List<string> { "player-1", "player-2" });
            Assert.Equal("player-1", game.CurrentPlayer());

            game.Play(0, 0);
            Assert.Equal("player-2", game.CurrentPlayer());
        }
    }
}
