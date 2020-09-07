using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.TicTacToe
{
    /// <summary>
    /// Exposes APIs for interacting with the game
    /// </summary>
    public class TicTacToeRunner
    {
        Player player;
        TicTacToeBoard board;
        // do not add any more instance or class variables, or properties

        public int BoardSize { get { return board.Size; } }

        public TicTacToeRunner ()
        {
            // initialize any values
        }

        public PlacementResult AttemptPlacePiece(Location location)
        {
            // use board class to place the piece and build a placement result
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates player to be the next player
        /// </summary>
        private void NextPlayer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints out the game board, you can only use 1 line for this method!
        /// </summary>
        public string PrintBoard()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the current player, you can only use 1 line for tthis method!
        /// </summary>
        public Player GetCurrentPlayer()
        {
            throw new NotImplementedException();
        }
    }
}
