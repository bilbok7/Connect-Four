using System;
using System.Collections.Generic;
using System.Text;

namespace Connect4
{
    class Board
    {
        int size = 8;
        int to_win = 4;
        int[,] state;
        string win_condition = "No Winner";
        int win_player = -1;
        public Board()
        {
            state = new int[size, size];
            reset();
        }

        public int drop(int col, int player)
        {
            // drop into col, return row or -1 if fail

            col -= 1;
            int row;
            int success = -1;

            if (col > size)
            {
                Console.Write("Board only has " + size + " columns \n");
                return -1;
            }

            if (col < 0)
            {
                Console.Write("Stay positive :p \n");
                return -1;
            }

            for (row = 0; row < size; row++)
            {
                if (state[row, col] == 0)
                {
                    state[row, col] = player;
                    success = row;
                    break;
                }
            }
            if (row == size)
            {
                Console.Write("Column Full \n");
                success = -1;
            }
            return success;

        }

        public bool check_win(int col, int row, int player)
        {

            col -= 1;
            int[] check_flags = { -1, 1, -2, 2, -3, 3 };

            //win count along each direction, forward and backward flags 
            int win_count, fflag, bflag;

            //4 directions (h,v,d1,d2)
            for (int direction = 0; direction < 4; direction++)
            {
                switch (direction)
                {
                    case 0: //Horizontal
                        fflag = 0;
                        bflag = 0;
                        win_count = 1;
                        for (int i = 0; i < 6; i++)
                        {
                            int this_col = col + check_flags[i];

                            if (this_col < 0 || this_col >= size) continue;

                            if (state[row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            Console.Write("WINNER!! - Horizontal \n");
                            win_condition = "Horizontal";
                            win_player = player;
                            return true;
                        }
                        break;

                    case 1: //Vertical
                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < 6; i++)
                        {
                            int this_row = row + check_flags[i];

                            if (this_row < 0 || this_row >= size) continue;

                            if (state[this_row, col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            Console.Write("WINNER!! - Vertical \n");
                            win_condition = "Vertical";
                            win_player = player;
                            return true;
                        }
                        break;


                    case 2: // == Diagonal

                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < 6; i++)
                        {
                            int this_row = row + check_flags[i];
                            int this_col = col + check_flags[i];

                            if (this_row < 0 || this_row >= size) continue;
                            if (this_col < 0 || this_col >= size) continue;

                            if (state[this_row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else fflag = 1;
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            Console.Write("WINNER!! - Diagonal \n");
                            win_condition = "Diagonal (positive)";
                            win_player = player;
                            return true;
                        }
                        break;

                    case 3: // != Diagonal

                        fflag = 0;
                        bflag = 0;
                        win_count = 1;

                        for (int i = 0; i < 6; i++)
                        {
                            int this_row = row - check_flags[i];
                            int this_col = col + check_flags[i];

                            if (this_row < 0 || this_row >= size) continue;
                            if (this_col < 0 || this_col >= size) continue;

                            if (state[this_row, this_col] == player)
                            {
                                win_count++;
                            }
                            else
                            {
                                if (check_flags[i] < 0) bflag = 1;
                                else { fflag = 1; }
                            }
                            if (bflag == 1 && fflag == 1) break;

                        }

                        if (win_count == to_win)
                        {
                            Console.Write("WINNER!! - Diagonal \n");
                            win_condition = "Diagonal (negative)";
                            win_player = player;
                            return true;
                        }
                        break;

                }

            }

            return false;

        }

        public void reset()
        {
            win_player = -1;
            win_condition = "No Winner";
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    state[row, col] = 0;
                }

            }

        }

        public void print_state()
        {
            Console.Write("\n----------------\n");
            for (int row = size - 1; row >= 0; row--)
            {
                string rstring = "";

                for (int col = 0; col < size; col++)
                {
                    rstring += " " + state[row, col];


                }

                Console.Write(rstring + "\n");

            }
            Console.Write(" ----------------\n");
            Console.Write(" 1 2 3 4 5 6 7 8\n");
            Console.Write(" ----------------\n");

            Console.Write("\nWinning condition: " + win_condition);
            if (win_player != -1) { Console.Write(" ** WINNER **: " + win_player); }
            Console.Write("\n\n\n");
        }

        ~Board()
        {

        }

        public void load_state()
        {

        }

        public void save_state()
        {

        }

    }
}