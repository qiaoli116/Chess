using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    class Bishop : PieceBase
    {
        public Bishop()
        {
            _type = PIECE_TYPE.Bishop;
        }

        public override bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap)
        {
            // if the target has a piece of the same side, not movable
            if (iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] == this.Color)
            {
                return false;
            }

            bool movable = true;

            // if the target is not in diagonal,
            // return
            if (Math.Abs(iTarget.Row - iSource.Row) != Math.Abs(iTarget.Column - iSource.Column))
            {
                movable = false;
            }
            else
            {
                int distance = Math.Abs(iTarget.Row - iSource.Row);
                int dr = (iTarget.Row - iSource.Row) > 0 ? 1 : -1;
                int dc = (iTarget.Column - iSource.Column) > 0 ? 1 : -1;
                // check if there is a piece in between source and target
                bool pieceInBetween = false;
                for (int i = 1; i < distance - 1; i++)
                {
                    if (iPieceColorMap.PieceColorMap[iSource.Row + i*dr, iSource.Column + i * dc] != PIECE_COLOR.Empty)
                    {
                        pieceInBetween = true;
                        break;
                    }
                }
                if (pieceInBetween == true)
                {
                    movable = false;
                }
            }

            return movable;
        }

        public override bool Move()
        {
            return true;
        }
    }
}
