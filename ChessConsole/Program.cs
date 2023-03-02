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
                    Console.Clear();
                    Screen.PrintBoard(game.Board);

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePosition = game.Board.ScreenPiece(origin).PosibleMove();

                    Console.Clear();
                    Screen.PrintBoard(game.Board, possiblePosition);

                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    game.ExecuteMove(origin, destiny);
                }              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}