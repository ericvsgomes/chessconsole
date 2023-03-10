using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class King : Piece
    {
        private ChessGame Game;

        public King(Board board, Color color, ChessGame game) : base(color, board)
        { 
            Game = game;            
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.ScreenPiece(position);
            return piece == null || piece.Color != Color;
        }

        private bool testRookToRock(Position pos)
        {
            Piece p = Board.ScreenPiece(pos);
            return p != null && p is Rook && p.Color == Color && p.AmountOfMoves == 0;
        }

        public override bool[,] PosiblesMoves()
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

            // #jogadaespecial roque
            if (AmountOfMoves == 0 && !Game.Check)
            { 
                // #jogadaespecial roque pequeno
                Position posRook1 = new Position(Position.Line, Position.Column + 3);
                if (testRookToRock(posRook1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.ScreenPiece(p1) == null && Board.ScreenPiece(p2) == null)
                    {
                        array[Position.Line, Position.Column + 2] = true;
                    }
                }

                // #jogadaespecial roque grande
                Position posRook2 = new Position(Position.Line, Position.Column - 4);
                if (testRookToRock(posRook2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.ScreenPiece(p1) == null && Board.ScreenPiece(p2) == null && Board.ScreenPiece(p3) == null)
                    {
                        array[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return array;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
