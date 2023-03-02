using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(color, board)
        { 
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.ScreenPiece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PosibleMove()
        {
            bool[,] array = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //ne
            pos.DefineValues(Position.Line - 1, Position.Column +1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //se
            pos.DefineValues(Position.Line +1, Position.Column + 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //so
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            //no
            pos.DefineValues(Position.Line -1, Position.Column - 1);
            if (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
            }

            return array;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
