using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;
using System.Numerics;

namespace ChessConsole.ChessEntities
{
    internal class Pawn : Piece
    {
        private ChessGame Game;

        public Pawn(Board board, Color color, ChessGame game) : base(color, board)
        {
            Game = game;
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

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPisition(pos) && Free(pos) && AmountOfMoves == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                // #jogada especial En Passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPisition(left) && ExistEnemy(left) && Board.ScreenPiece(left) == Game.VulnerableEnPassant)
                    {
                        array[left.Line -1, left.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPisition(rigth) && ExistEnemy(rigth) && Board.ScreenPiece(rigth) == Game.VulnerableEnPassant)
                    {
                        array[rigth.Line -1, rigth.Column] = true;
                    }
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPisition(pos) && Free(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPisition(pos) && Free(pos) && AmountOfMoves == 0)
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPisition(pos) && ExistEnemy(pos))
                {
                    array[pos.Line, pos.Column] = true;
                }

                // #jogada especial En Passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPisition(left) && ExistEnemy(left) && Board.ScreenPiece(left) == Game.VulnerableEnPassant)
                    {
                        array[left.Line + 1, left.Column] = true;
                    }
                    Position rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPisition(rigth) && ExistEnemy(rigth) && Board.ScreenPiece(rigth) == Game.VulnerableEnPassant)
                    {
                        array[rigth.Line + 1, rigth.Column] = true;
                    }
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
