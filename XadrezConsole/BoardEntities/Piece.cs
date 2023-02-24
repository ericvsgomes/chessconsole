﻿using XadrezConsole.BoardEntities.Enums;

namespace XadrezConsole.BoardEntities
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int AmountOfMoves { get; set; }
        public Board Board { get; set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;            
            Board = board;
            AmountOfMoves = 0;
        }
    }
}