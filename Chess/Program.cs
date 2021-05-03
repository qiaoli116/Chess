using Chess.Classes;
using Chess.Classes.Pieces;
using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static Board board;
        static void Main(string[] args)
        {
            init();
            Console.WriteLine("Type \"help\" to see all supported commands." );
            bool exit = false;
            while (!exit)
            {
                Console.Write("$ ");
                string input = Console.ReadLine();

                string cmdPattern = "^([a-zA-Z]+)";
                Match m = Regex.Match(input, cmdPattern, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    string cmd = m.Value.ToLower();
                    Console.WriteLine(cmd);
                    switch (cmd)
                    {
                        case "help":
                            Console.WriteLine("place command");
                            Console.WriteLine("    structure: place type name color row column");
                            Console.WriteLine("    example:   place knight w_knig_1 white 1 2");
                            Console.WriteLine("move command");
                            Console.WriteLine("    structure: move current_row current_column target_row target column");
                            Console.WriteLine("    example:   move 1 2 2 5");
                            Console.WriteLine("show command");
                            Console.WriteLine("    structure: show");
                            Console.WriteLine("exit command");
                            Console.WriteLine("    structure: exit");
                            Console.WriteLine("help command");
                            Console.WriteLine("    structure: help");
                            break;
                        case "exit":
                            exit = true;
                            break;
                        case "move":
                            // move source.r source.c target.r target.c
                            string movePattern = @"(\d+)";
                            int[] num = { 0, 0, 0, 0 };
                            Regex.Matches(input, movePattern);
                            int i = 0;
                            foreach (Match match in Regex.Matches(input, movePattern, RegexOptions.IgnoreCase))
                            {
                                num[i] = Int32.Parse(match.Value);
                                i++;
                            }
                            Console.WriteLine($"Move {board.ChessBoard[num[0], num[1]].Name} [{num[0]}, {num[1]}] -> [{num[2]}, {num[3]}]");
                            bool result = board.MoveAPiece(new Position { Row = num[0], Column = num[1] }, new Position { Row = num[2], Column = num[3] });
                            Console.WriteLine(result);
                            break;
                        case "show":
                            board.PrintBoard();
                            break;
                        case "place":
                            // place type name color position.r position.c
                            string placePattern = @"place\s+([a-zA-Z]+)\s+(\w+)\s+([a-zA-Z]+)\s+([0-9]+)\s+([0-9]+)";
                            m = Regex.Match(input, placePattern, RegexOptions.IgnoreCase);
                            if (m.Success)
                            {
                                Console.WriteLine($"{m.Groups[0]}, {m.Groups[1]}, {m.Groups[2]}, {m.Groups[3]},  {m.Groups[4]}, {m.Groups[5]}");

                                string typeName = m.Groups[1].ToString().ToLower();
                                PIECE_TYPE type = PIECE_TYPE.Invalid;
                                try
                                {
                                    type = (PIECE_TYPE)Enum.Parse(typeof(PIECE_TYPE), typeName, true);
                                }
                                catch (ArgumentException) { }

                                string name = m.Groups[2].ToString().ToLower();

                                
                                string colorName = m.Groups[3].ToString().ToLower();
                                PIECE_COLOR color = PIECE_COLOR.Invalid;
                                try
                                {
                                    color = (PIECE_COLOR)Enum.Parse(typeof(PIECE_COLOR), colorName, true);
                                }
                                catch (ArgumentException){}

                                Position position = new Position { 
                                    Row = Int32.Parse(m.Groups[4].ToString()), 
                                    Column = Int32.Parse(m.Groups[5].ToString())
                                };

                                if(type != PIECE_TYPE.Invalid && color != PIECE_COLOR.Invalid)
                                {
                                    Console.WriteLine($"place {type.ToString()}  {name} to [{position.Row}, {position.Column}]");
                                    switch (type)
                                    {
                                        case PIECE_TYPE.King:
                                            board.PlaceAPiece(new King { Color = color, Name = name }, position);
                                            break;
                                        case PIECE_TYPE.Queen:
                                            board.PlaceAPiece(new Queen { Color = color, Name = name }, position);
                                            break;
                                        case PIECE_TYPE.Rook:
                                            board.PlaceAPiece(new Rook { Color = color, Name = name }, position);
                                            break;
                                        case PIECE_TYPE.Bishop:
                                            board.PlaceAPiece(new Bishop { Color = color, Name = name }, position);
                                            break;
                                        case PIECE_TYPE.Knight:
                                            board.PlaceAPiece(new Knight { Color = color, Name = name }, position);
                                            break;
                                        case PIECE_TYPE.Pawn:
                                            board.PlaceAPiece(new Pawn (1) { Color = color, Name = name }, position);
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                }
                            }
                            break;
                        default:
                            break;
                    }


                }

            }
        }

        static void init()
        {
            board = new Board();

            Rook b_rook_1 = new Rook { Color = PIECE_COLOR.Black, Name = "b_rook_1" };
            Rook b_rook_2 = new Rook { Color = PIECE_COLOR.Black, Name = "b_rook_2" };
            Rook w_rook_1 = new Rook { Color = PIECE_COLOR.White, Name = "w_rook_1" };


            board.PlaceAPiece(b_rook_1, new Position { Row = 0, Column = 0 });
            board.PlaceAPiece(b_rook_2, new Position { Row = 0, Column = 1 });
            board.PlaceAPiece(w_rook_1, new Position { Row = 3, Column = 0 });

        }
    }
}
