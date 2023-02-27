﻿namespace ChessConsole.BoardEntities
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

        public void PutPiece(Piece p, Position pos)
        {
            Piece[pos.Line, pos.Column] = p;
            p.Position = pos;
        }
    }
}
