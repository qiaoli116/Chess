using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    abstract class PieceBase : IPiece
    {
        public PIECE_COLOR Color { get; set; }

        protected PIECE_TYPE _type;
        public PIECE_TYPE Type { get => _type; }
        public string Name { get; set; }

        public abstract bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap);
        public abstract bool Move();

    }
}
