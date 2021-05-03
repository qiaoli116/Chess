using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    class King : PieceBase
    {
        public King()
        {
            _type = PIECE_TYPE.King;
        }

        public override bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap)
        {

            // if the target has a piece of the same side, not movable
            if (iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] == this.Color)
            {
                return false;
            }

            bool movable = true;

            if (!(
                (iTarget.Row == iSource.Row - 1 && iTarget.Column == iSource.Column) ||
                (iTarget.Row == iSource.Row + 1 && iTarget.Column == iSource.Column) ||
                (iTarget.Row == iSource.Row && iTarget.Column == iSource.Column - 1) ||
                (iTarget.Row == iSource.Row && iTarget.Column == iSource.Column + 1)
                ))
            {
                movable = false;
            }

            return movable;
        }

        public override bool Move()
        {
            return true;
        }
    }
}
