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

                board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                board.PutPiece(new King(board, Color.White), new Position(3, 5));

                Screen.PrintBoard(board);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}