using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Position: IPosition
    {
        private int _row;
        public int Row
        {
            get {
                return _row;
            }
            set 
            {
                // _row must be in range [0, C.MaxNumberOfColumn - 1]
                if (value < 0)
                {
                    _row = 0;
                }
                else if (value > Constants.MaxNumberOfRow - 1)
                {
                    _row = Constants.MaxNumberOfRow - 1;
                }
                else
                {
                    _row = value;
                }
            }
        }

        private int _column;
        public int Column
        {
            get
            {
                return _column;
            }
            set
            {
                // _column must be in range [0, C.MaxNumberOfColumn - 1]
                if (value < 0)
                {
                    _column = 0;
                }
                else if (value > Constants.MaxNumberOfColumn - 1)
                {
                    _column = Constants.MaxNumberOfColumn - 1;
                }
                else
                {
                    _column = value;
                }
               
            }
        }
    }
}
