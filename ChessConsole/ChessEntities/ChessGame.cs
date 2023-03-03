using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;
using ChessConsole.BoardEntities.Exceptions;

namespace ChessConsole.ChessEntities
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPieces();
        }

        public void ExecuteMove (Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.AddAmountOfMoves();
            Piece pieceCaptured = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
        }

        public void PerformsMove (Position origin, Position destiny)
        {
            ExecuteMove(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position pos)
        {
            if (Board.ScreenPiece(pos) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position.");
            }
            if (CurrentPlayer != Board.ScreenPiece(pos).Color)
            {
                throw new BoardException("The chosen source piece is not yours.");
            }
            if (!Board.ScreenPiece(pos).ExistPosibleMove())
            {
                throw new BoardException("There are no possible moves for the chosen piece.");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.ScreenPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position.");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            } else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
        }
    }
}
