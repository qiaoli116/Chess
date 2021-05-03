using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{

    class Board: IPieceColorMap
    {

        public IPiece[,] ChessBoard;

        public List<IPiece> CapturedWhite;
        public List<IPiece> CapturedBlack;

        public PIECE_COLOR[,] PieceColorMap {
            get
            {
                PIECE_COLOR[,] map = new PIECE_COLOR[Constants.MaxNumberOfRow, Constants.MaxNumberOfColumn];
                for (int i = 0; i < Constants.MaxNumberOfRow; i++)
                {
                    for (int j = 0; j < Constants.MaxNumberOfColumn; j++)
                    {
                        map[i, j] = (ChessBoard[i, j] == null) ? PIECE_COLOR.Empty : ChessBoard[i, j].Color;                  
                    }
                }
                return map;
            }
        }

        public Board()
        {
            EmptyBoard();

        }

        public void EmptyBoard()
        {
            ChessBoard = new IPiece[Constants.MaxNumberOfRow, Constants.MaxNumberOfColumn];

            for (int i = 0; i < Constants.MaxNumberOfRow; i++)
            {
                for (int j = 0; j < Constants.MaxNumberOfColumn; j++)
                {
                    ChessBoard[i, j] = null;
                }
            }

            CapturedBlack = new List<IPiece>();
            CapturedWhite = new List<IPiece>();
        }

        public bool PlaceAPiece(IPiece piece, Position position)
        {
            if (ChessBoard[position.Row, position.Column] != null)
            {
                return false;
            }

            ChessBoard[position.Row, position.Column] = piece;
            return true;
        }

        public bool MoveAPiece(Position source, Position target)
        {
            IPiece piece = ChessBoard[source.Row, source.Column];
            // if nothing in the original position, return false
            if(piece == null)
            {
                return false;
            }

            // if the target position is the same as the source position, return false
            if (target.Row == source.Row && target.Column == source.Column)
            {
                return false;
            }

            // step 1: determine if it is possible to move to the target position
            bool movable = piece.Movable(source, target, this);

            // step 2: make a move
            //         if movable, determine if it is a simple move or move & capture
            bool moved = true;
            if(movable == true)
            {
                // check what is at the target position
                // if empty, move the piece
                // if different color, capture the target piece
                IPiece targetPiece = ChessBoard[target.Row, target.Column];
                if (targetPiece == null)
                {
                    // a simple move

                    ChessBoard[target.Row, target.Column] = ChessBoard[source.Row, source.Column];
                    ChessBoard[source.Row, source.Column] = null;
                }
                else
                {
                    if (targetPiece.Color == piece.Color)
                    {
                        // this should not happen, this check should done in piece.Movable method.
                        // however, to make it safe, do a double check to make sure.
                        moved = false;
                    }
                    else
                    {
                        // capture
                        if (ChessBoard[target.Row, target.Column].Color == PIECE_COLOR.Black)
                        {
                            CapturedBlack.Add(ChessBoard[target.Row, target.Column]);
                        }
                        else if (ChessBoard[target.Row, target.Column].Color == PIECE_COLOR.White)
                        {
                            CapturedWhite.Add(ChessBoard[target.Row, target.Column]);
                        } // else do nothing

                        // move
                        ChessBoard[target.Row, target.Column] = ChessBoard[source.Row, source.Column];
                        ChessBoard[source.Row, source.Column] = null;

                    }
                }
            }
            else
            {
                moved = false;
            }
            

            return moved;
        }

        public void PrintBoard()
        {
            // Console.Clear();
            Console.WriteLine("\n      0          1          2          3          4          5          6          7");
            Console.WriteLine("\n  +---------+----------+----------+----------+----------+----------+----------+----------+");
            for (int i = 0; i < Constants.MaxNumberOfRow; i++)
            {
                Console.Write(i + " |");
                for (int j = 0; j < Constants.MaxNumberOfColumn; j++)
                {
                    if(ChessBoard[i, j] != null)
                    {
                        Console.Write(ChessBoard[i, j].Name);
                    }
                    else
                    {
                        Console.Write("        ");
                    }
                    Console.Write(" | ");

                }
                Console.Write(" " + i);
                Console.WriteLine("\n  +---------+----------+----------+----------+----------+----------+----------+----------+");
                
            }
            Console.WriteLine("\n      0          1          2          3          4          5          6          7");

            Console.Write("\nCaptured Black: ");
            foreach (IPiece piece in CapturedBlack)
            {
                Console.Write(piece.Name + ", ");
            }
            Console.Write("\nCaptured White: ");
            foreach (IPiece piece in CapturedWhite)
            {
                Console.Write(piece.Name + ", ");
            }
            Console.WriteLine("");
        }
    }
}
