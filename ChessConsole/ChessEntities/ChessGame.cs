using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;
using ChessConsole.BoardEntities.Exceptions;
using System.Reflection.PortableExecutable;

namespace ChessConsole.ChessEntities
{
    internal class ChessGame
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check {  get; private set; }

        public ChessGame()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMove(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.AddAmountOfMoves();
            Piece pieceCaptured = Board.RemovePiece(destiny);
            Board.PutPiece(p, destiny);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }
            return pieceCaptured;
        }

        public void UndoMove(Position origin, Position destiny, Piece pieceCaptured)
        {
            Piece p = Board.RemovePiece(destiny);
            p.SubtractAmountOfMoves();
            if (pieceCaptured != null)
            {
                Board.PutPiece(pieceCaptured, destiny);
                Captured.Remove(pieceCaptured);
            }
            Board.PutPiece(p, origin);
        }

        public void PerformsMove(Position origin, Position destiny)
        {
            Piece pieceCaptured = ExecuteMove(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destiny, pieceCaptured);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (CheckmateTest(Opponent(CurrentPlayer)))
            {
                Finished = true;
            } else
            {
                Turn++;
                ChangePlayer();
            }
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
            if (!Board.ScreenPiece(origin).PosibleMove(destiny))
            {
                throw new BoardException("Invalid destiny position.");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece k = King(color);
            if (ReferenceEquals == null)
            {
                throw new BoardException("There is no " + color + "king on the board!");
            }

            foreach (Piece x in PiecesInGame(Opponent(color)))
            {
                bool[,] vector = x.PosiblesMoves();
                if (vector[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] vector = x.PosiblesMoves();
                for (int i = 0; i < Board.Columns; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (vector[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece pieceCaptured = ExecuteMove(origin, new Position(i, j));
                            bool checkTest = IsInCheck(color);
                            UndoMove(origin, destiny, pieceCaptured);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char collumn, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(collumn, line).ToPosition());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            //PutNewPiece('c', 1, new Rook(Board, Color.White));
            //PutNewPiece('c', 2, new Rook(Board, Color.White));
            //PutNewPiece('d', 2, new Rook(Board, Color.White));
            //PutNewPiece('e', 2, new Rook(Board, Color.White));
            //PutNewPiece('e', 1, new Rook(Board, Color.White));
            //PutNewPiece('d', 1, new King(Board, Color.White));

            //PutNewPiece('c', 7, new Rook(Board, Color.Black));
            //PutNewPiece('c', 8, new Rook(Board, Color.Black));
            //PutNewPiece('d', 7, new Rook(Board, Color.Black));
            //PutNewPiece('e', 7, new Rook(Board, Color.Black));
            //PutNewPiece('e', 8, new Rook(Board, Color.Black));
            //PutNewPiece('d', 8, new King(Board, Color.Black));

            PutNewPiece('c', 1, new Rook(Board, Color.White));
            PutNewPiece('h', 7, new Rook(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));

            PutNewPiece('b', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 8, new King(Board, Color.Black));           

        }
    }
}
