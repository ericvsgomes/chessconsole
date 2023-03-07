using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(color, board)
        {
        }

        public override bool[,] PosiblesMoves()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
