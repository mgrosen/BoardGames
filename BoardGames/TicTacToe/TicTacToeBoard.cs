using System;
using System.Text;

namespace BoardGames.TicTacToe
{
    /// <summary>
    /// Encapsulates the board state. Most of your code goes here!
    /// </summary>
    public class TicTacToeBoard
    {
        public int Size { get; private set; }
        private Player[,] Board;
        private int PiecesPlaced;

        // you may add as many variables as you need (I used 4 others)

        /// <summary>
        /// Creates a new board
        /// </summary>
        /// <param name="size">Size must be an odd number</param>
        public TicTacToeBoard(int size)
        {
            if (size % 2 == 0)
            {
                throw new Exception("Board need to be an odd size");
            }

            // initialize any variables here
        }

        /// <summary>
        /// Attempts to place the given player on the board.
        /// Make sure to: 
        ///  1) keep track of the number of pieces placed
        ///  2) use the LocationIsValid method
        ///  3) use the IsOccupied method
        ///  4) return an appropriate BoardPlacementResult
        ///  
        /// Optional: depending on your solution you may use
        /// OnPosDiag and/or OnNegDiag in this method
        /// </summary>
        /// <param name="player">Who to put down</param>
        /// <param name="location">Where to put them down</param>
        /// <returns><see cref="BoardPlacementResult"/></returns>
        internal BoardPlacementResult AttemptPlacePiece(Player player, Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if location is on the "backward slash" Diagonal.
        /// Try to do it in one line!
        /// </summary>
        /// <param name="location"></param>
        private bool OnPosDiag(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if location is on the "forward slash" Diagonal.
        /// Try to do it in one line!
        /// </summary>
        /// <param name="location"></param>
        private bool OnNegDiag(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if a location is already occupied.
        /// Try to do it in one line!
        /// </summary>
        /// <param name="location"></param>
        private bool IsOccupied(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// If the location is within the bounds of the board
        /// </summary>
        /// <param name="location"></param>
        private bool LocationIsValid(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the game board in a winning state.
        /// hint: enums have an int value - can that be useful here?
        /// </summary>
        internal bool IsWon()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a string representation of the current game board.
        /// </summary>
        internal string PrintBoard()
        {
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < Size; r++)
            {
                sb.Append('|');
                for (int c = 0; c < Size; c++)
                {
                    sb.Append(Board[r,c].ToString("g"));
                    sb.Append('|');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}