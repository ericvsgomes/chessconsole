using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(color, board)
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

            //acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            //esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            //abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // NO
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }

            // NE
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }

            // SE
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }

            // SO
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPisition(pos) && CanMove(pos))
            {
                array[pos.Line, pos.Column] = true;
                if (Board.ScreenPiece(pos) != null && Board.ScreenPiece(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }

            return array;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
