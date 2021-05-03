using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    enum PIECE_COLOR
    {
        Black,
        White,
        Empty,

        Size,
        Invalid
    }
    enum PIECE_TYPE
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn,

        Size,
        Invalid
    }

    interface IPiece
    {
        
        PIECE_COLOR Color { get; set; }
        PIECE_TYPE Type { get; }
        string Name { get; set; }

        bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceMap);
    }
    
}
