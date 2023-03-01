using ChessConsole.BoardEntities.Exceptions;

namespace ChessConsole.BoardEntities
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Piece;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Piece = new Piece[lines, columns];
        }

        public Piece ScreenPiece(int line, int column)
        {
            return Piece[line,column];
        }

        public Piece ScreenPiece(Position position)
        {
            return Piece[position.Line, position.Column];
        }

        public bool ExistPiece(Position position)
        {
            ValidatePisition(position);
            return ScreenPiece(position) != null;
        }

        public void PutPiece(Piece p, Position position)
        {
            if(ExistPiece(position))
            {
                throw new BoardException("There is already a piece in that position.");
            }
            Piece[position.Line, position.Column] = p;
            p.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (ScreenPiece(position) == null)
            {
                return null;
            }
            Piece aux = ScreenPiece(position);
            aux.Position = null;
            Piece[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPisition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePisition(Position position)
        {
            if (!ValidPisition(position))
            {
                throw new BoardException("Invalid position.");
            }
        }
    }
}
