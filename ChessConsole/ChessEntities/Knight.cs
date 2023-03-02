using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(color, board)
        {
        }

        public override bool[,] PosibleMove()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
