using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
        { 
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
