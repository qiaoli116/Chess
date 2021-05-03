using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Interfaces
{
    interface IPieceColorMap
    {
        PIECE_COLOR[,] PieceColorMap { get; }
    }
}
