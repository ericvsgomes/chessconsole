using ChessConsole.BoardEntities;

namespace ChessConsole
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.ScreenPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    } 
                    else
                    {
                        Console.Write(board.ScreenPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
