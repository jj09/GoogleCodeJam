using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemA.TicTacToeTomek
{
    class TicTacToeTomek
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader("../../A-large.in"))
                {
                    using (StreamWriter sw = new StreamWriter("../../A-large.out"))
                    {
                        string line = sr.ReadLine();
                        int casesCount = int.Parse(line);

                        for (int i = 0; i < casesCount; ++i)
                        {
                            string result = "Game has not completed";
                            bool win = false;
                            bool emptyFields = false;
                            string[] board = new string[4];

                            //read board
                            for (int j = 0; j < board.Length; ++j)
                            {
                                board[j] = sr.ReadLine();
                                if (board[j].Contains('.'))
                                    emptyFields = true;
                            }

                            //check horizontal
                            for (int j = 0; j < board.Length; ++j)
                            {                                
                                if (CheckWin(board[j]))
                                {
                                    result = GetWinner(board[j]);
                                    win = true;
                                    break;
                                }                                
                            }

                            if (win == false)
                            {
                                //check vertical
                                for (int j = 0; j < board.Length; ++j)
                                {
                                    string v = board[0][j].ToString() + board[1][j] + board[2][j] + board[3][j];

                                    if (CheckWin(v))
                                    {
                                        result = GetWinner(v);
                                        win = true;
                                        break;
                                    }

                                }

                                //check crosses
                                if (win == false)
                                {
                                    var crossLeft = board[0][0].ToString() + board[1][1] + board[2][2] + board[3][3];
                                    if (CheckWin(crossLeft))
                                    {
                                        result = GetWinner(crossLeft);
                                        win = true;
                                    }
                                    if (win == false)
                                    {
                                        var crossRight = board[0][3].ToString() + board[1][2] + board[2][1] + board[3][0];
                                        if (CheckWin(crossRight))
                                        {
                                            result = GetWinner(crossRight);
                                            win = true;
                                        }
                                    }
                                }
                            }

                            if (win == false && emptyFields == false)
                            {
                                result = "Draw";
                            }

                            sw.WriteLine("Case #" + (i + 1) + ": " + result);
                            Console.WriteLine("Case #" + (i + 1) + ": " + result);

                            sr.ReadLine();  //read empty
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetWinner(string values)
        {
            if (values.Contains('X'))
                return "X won";
            else
                return "O won";
        }

        private static bool CheckWin(string values)
        {
            if (values.Contains('.'))
                return false;

            if (values.Contains('X') && values.Contains('O') == false)
                return true;

            if (values.Contains('O') && values.Contains('X') == false)
                return true;

            return false;
        }


    }
}
