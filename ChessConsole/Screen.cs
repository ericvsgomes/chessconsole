using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;
using ChessConsole.ChessEntities;

namespace ChessConsole
{
    internal class Screen
    {

        public static void PrintGame(ChessGame game)
        {
            PrintBoard(game.Board);
            Console.WriteLine();
            PrintCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.Turn);
            Console.WriteLine("Waiting for move: " + game.CurrentPlayer);
            if (game.Check)
            {
                Console.WriteLine("CHECK!");
            }
        }

        public static void PrintCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            PrintSet(game.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(game.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.ScreenPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possiblePosition)
        {
            ConsoleColor backgroundOrigin = Console.BackgroundColor;
            ConsoleColor backgroundChanged  = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePosition[i, j])
                    {
                        Console.BackgroundColor = backgroundChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOrigin;
                    }
                    PrintPiece(board.ScreenPiece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = backgroundOrigin;
            }
            Console.WriteLine("  a b c d e f g h");            
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char collumn = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(collumn, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            } 
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
