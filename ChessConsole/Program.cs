using ChessConsole.BoardEntities;
using ChessConsole.ChessEntities;

namespace ChessConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                ChessGame game = new ChessGame();

                while (!game.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(game);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        game.ValidateOriginPosition(origin);

                        bool[,] possiblePosition = game.Board.ScreenPiece(origin).PosibleMove();

                        Console.Clear();
                        Screen.PrintBoard(game.Board, possiblePosition);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadChessPosition().ToPosition();
                        game.ValidateDestinyPosition(origin, destiny);

                        game.PerformsMove(origin, destiny);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintGame(game);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}