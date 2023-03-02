using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.BoardEntities
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMoves { get; set; }
        public Board Board { get; set; }

        public Piece(Color color, Board board)
        {
            Color = color;            
            Board = board;
            AmountOfMoves = 0;
        }

        public void AddAmountOfMoves()
        {
            AmountOfMoves++;
        }

        public abstract bool[,] PosibleMove();
    }
}
