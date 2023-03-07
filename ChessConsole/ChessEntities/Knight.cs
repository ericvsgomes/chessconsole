using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(color, board)
        {
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.ScreenPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PosiblesMoves()
        {
            bool[,] array = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            return array;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}
