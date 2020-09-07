using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGames.TicTacToe
{
    /// <summary>
    /// Result when calling the runner. Do not change anything in this class.
    /// </summary>
    public class PlacementResult
    {
        public string NextPlayer { get; private set; }
        public bool IsWon { get; private set; }
        public BoardPlacementResult BoardPlacementResult { get; private set; }

        public PlacementResult(string nextPlayer, bool isWon, BoardPlacementResult boardPlacementResult)
        {
            this.NextPlayer = nextPlayer;
            this.IsWon = isWon;
            this.BoardPlacementResult = boardPlacementResult;
        }
    }

    /// <summary>
    /// Result when the runner calls the board class
    /// </summary>
    public class Location
    {
        public int X { get; private set; }
        public int Y;

        public Location(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    /// <summary>
    /// Representation of players.
    /// Can you think of why I might have used -1 and 1 as the values for the players?
    /// </summary>
    public enum Player
    {
        X = -1,
        _ = 0,
        O = 1
    }

    /// <summary>
    /// Simple messsing from the board class about how the placement went
    /// </summary>
    public enum BoardPlacementResult
    {
        Success,
        InvalidLocation,
        LocationOccupied,
        BoardFilled
    }
}
