using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        string[,] board;
        int player; 

        public Game(){
            board = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            player = 1;

        }

        public void startPlaying()
        {
            displayBoard();
            for (int i = 0; i < 9; i++)
            {
                int st = NextMove();
                Console.Clear();
                displayBoard();

                if (st != -1)
                {
                    Console.WriteLine("Player {0} is the winner", st);
                    return;
                }

            }
        }


        public void displayBoard()
        {
            Console.WriteLine("      |     |");
            Console.WriteLine("   {0}  |  {1}  |  {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("      |     |");
            
            Console.WriteLine(" -----+-----+-----");

            Console.WriteLine("      |     |");
            Console.WriteLine("   {0}  |  {1}  |  {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("      |     |");
            
            Console.WriteLine(" -----+-----+-----");
            
            Console.WriteLine("      |     |");
            Console.WriteLine("   {0}  |  {1}  |  {2} ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("      |     |");
        }

        public int NextMove()
        {
            int move;
            do
            {
                try
                {
                    Console.Write("Player {0} : Enter the Field -->  ",player);
                    move = int.Parse(Console.ReadLine());

                    if(move < 1 || move > 9 )
                    {
                        throw new Exception("Enter the field in the range between 1-9 only");
                    }

                    move -= 1;
                    int i = move / 3 , j = move % 3;

                    if (board[i, j] == "X" || board[i, j] == "O") throw new Exception("Try Choosing Another Field");

                    if(player == 1)    board[i, j] = "X";
                    else                board[i, j] = "O";
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nInvalid Input. "+e.Message+"\n");
                }
            } while (true);          

            if(checkWinner())
                return player;

            player = (player == 1 ? 2 : 1);
            return -1;
        }

        public bool checkWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i]) return true;
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2]) return true;
            }

            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) return true;
            if (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]) return true;

            return false;

        }


    }
}
