using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;
using System.Numerics;

namespace ChessConsole.ChessEntities
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(color, board)
        {
        }
        
        private bool ExistEnemy(Position position)
        {
            Piece p = Board.ScreenPiece(position);
            return p != null && p.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.ScreenPiece(position) == null;
        }

        public override bool[,] PosiblesMoves()
        {
            bool[,] array = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPisition(pos) && Free(pos)) {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line - 2, pos.Column);
                if (Board.ValidPisition(pos) && Free(pos) && AmountOfMoves == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line - 1, pos.Column - 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line - 1, pos.Column + 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPisition(pos) && Free(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line + 2, pos.Column);
                if (Board.ValidPisition(pos) && Free(pos) && AmountOfMoves == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line + 1, pos.Column - 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(pos.Line + 1, pos.Column + 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }
            }

            return array;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
