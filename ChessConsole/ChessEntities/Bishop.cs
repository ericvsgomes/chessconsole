﻿using ChessConsole.BoardEntities;
using ChessConsole.BoardEntities.Enums;

namespace ChessConsole.ChessEntities
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}