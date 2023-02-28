using ChessConsole.BoardEntities;
using ChessConsole.ChessEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Rook(board, Color.Preta), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Preta), new Position(1, 7));
                board.PutPiece(new King(board, Color.Preta), new Position(0, 2));

                Screen.PrintBoard(board);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}