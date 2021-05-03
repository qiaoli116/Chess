using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    class Rook : PieceBase
    {

        public Rook()
        {
            _type = PIECE_TYPE.Rook;
        }

        public override bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap)
        {

            // if the target has a piece of the same side, not movable
            if (iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] == this.Color)
            {
                return false;
            }

            bool movable = true;

            // if the target is not at the same row or same column as the source,
            // return false
            if (iTarget.Row != iSource.Row && iTarget.Column != iSource.Column)
            {
                movable = false;
            }
            else if (iTarget.Row == iSource.Row && iTarget.Column != iSource.Column)
            {
                // moving horizontally
                // check if there is a piece in between source and target
                int low = iSource.Column < iTarget.Column ? iSource.Column : iTarget.Column;
                int high = iSource.Column > iTarget.Column ? iSource.Column : iTarget.Column;
                bool pieceInBetween = false;
                for (int i = low + 1; i <= high - 1; i++)
                {
                    if (iPieceColorMap.PieceColorMap[iTarget.Row, i] != PIECE_COLOR.Empty)
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
            else if (iTarget.Row != iSource.Row && iTarget.Column == iSource.Column)
            {
                // moving vertically
                // check if there is a piece in between source and target
                int low = iSource.Row < iTarget.Row ? iSource.Row : iTarget.Row;
                int high = iSource.Row > iTarget.Row ? iSource.Row : iTarget.Row;
                bool pieceInBetween = false;
                for (int i = low + 1; i <= high - 1; i++)
                {
                    if (iPieceColorMap.PieceColorMap[i, iSource.Column] != PIECE_COLOR.Empty)
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
