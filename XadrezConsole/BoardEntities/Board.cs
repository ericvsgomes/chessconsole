namespace XadrezConsole.BoardEntities
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
    }
}
