using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    class Queen : PieceBase
    {
        public Queen()
        {
            _type = PIECE_TYPE.Queen;
        }
        public override bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap)
        {
            throw new NotImplementedException();
        }

        public override bool Move()
        {
            return true;
        }
    }
}
