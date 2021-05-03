using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes.Pieces
{
    class Pawn : PieceBase
    {
        private bool _firstMove;
        public bool FirstMove { get { return _firstMove; } }

        private int _direction;
        public int Direction { get { return _direction; } }

        public Pawn(int direction)
        {
            _type = PIECE_TYPE.Pawn;
            _firstMove = true;
            _direction = direction >= 0 ? 1 : -1;
        }

        public override bool Movable(IPosition iSource, IPosition iTarget, IPieceColorMap iPieceColorMap)
        {
            bool movable = true;

            if (iTarget.Column == iSource.Column)
            {
                if(iTarget.Row == iSource.Row + _direction)
                {
                    if (iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] != PIECE_COLOR.Empty)
                    {
                        movable = false;
                    } // else nothing to do
                } 
                else if (iTarget.Row == iSource.Row + 2*_direction)
                {
                    if (_firstMove)
                    {
                        if (
                            iPieceColorMap.PieceColorMap[iSource.Row + _direction, iSource.Column] != PIECE_COLOR.Empty ||
                            iPieceColorMap.PieceColorMap[iSource.Row + 2 * _direction, iSource.Column] != PIECE_COLOR.Empty )
                        {
                            movable = false;
                        } // else nothing to do
                    }
                    else
                    {
                        movable = false;
                    }
                }
                else
                {
                    movable = false;
                }

            }
            else if (
                iTarget.Column == iSource.Column + 1 ||
                iTarget.Column == iSource.Column - 1)
            {
                // moving diagonally
                if (iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] == this.Color ||
                    iPieceColorMap.PieceColorMap[iTarget.Row, iTarget.Column] == PIECE_COLOR.Empty)
                {
                    // capture only
                    movable = false;
                } // else nothing to do
            }
            else
            {
                movable = false;
            }

            return movable;
        }

        public override bool Move()
        {
            _firstMove = false;
            return true;
        }
    }
}
