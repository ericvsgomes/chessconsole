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

        public void SubtractAmountOfMoves()
        {
            AmountOfMoves--;
        }

        public bool ExistPosibleMove()
        {
            bool[,] array = PosiblesMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (array[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PosibleMove(Position pos)
        {
            return PosiblesMoves()[pos.Line, pos.Column];
        }

        public abstract bool[,] PosiblesMoves();
    }
}
