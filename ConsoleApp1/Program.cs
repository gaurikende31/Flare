using System;
using System.Collections.Generic;

namespace Battleship
{

    class Battleship_Demo
    {

        public List<string> ship;
        public char[,] game_board = new char[10, 10];

        
        public Battleship_Demo()
        {
            //Todo : Ship location be taken from user.
            ship = new List<string>(new string[] { "1|1", "1|2", "1|3", "1|4" }); 
            Board_Initialize();
        }

        
        public void Board_Initialize()  
        {
            //Todo : Boardsize can be taken from user.
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    game_board[i, j] = 'O';
                }
            }

        }
        public void FireRound ()
        {
            //Todo : Validation on user input. 
            Console.WriteLine("Please enter row number between 0 to 9:  "); 
            int x = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter column number between 0 to 9:  ");
            int y = Int32.Parse(Console.ReadLine());

            Check_Ship_Hit_Or_Miss(x, y);

            Print_Board();

        }


        public void Check_Ship_Hit_Or_Miss(int x, int y)
        {

            if(game_board[x, y] == 'X'|| game_board[x, y] == '-')
            {
                //Todo : Refactor and ask user to enter different coordinates.
                Console.WriteLine("Chance wasted");
                return;
            }

            if (ship.Remove(x.ToString() + "|" + y.ToString()))
            {
                Console.WriteLine("Hit");
                game_board[x, y] = 'X';

            }
            else
            {
                Console.WriteLine("Miss");
                game_board[x, y] = '-';
            }
        }


        public void Print_Board()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(game_board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship Game");

            Battleship_Demo player1 = new Battleship_Demo(); //Initialize the board and ship for player 1
            Battleship_Demo player2 = new Battleship_Demo(); //Initialize the board and ship for player 2


            while (player1.ship.Count != 0 && player2.ship.Count != 0) //Game continues as no one has lost the game
            {
                Console.WriteLine(" Player One Turn");

                player2.FireRound();

                if (player2.ship.Count != 0)
                {
                    Console.WriteLine(" Player Two Turn");
                    player1.FireRound();

                }
            }

            if (player1.ship.Count != 0) //Second player's ship has sunk so first player is winner
            {
                Console.WriteLine("Congratulations Player One ");
            }
            else //First player's ship has sunk second player is winner
            {
                Console.WriteLine("Congratulations Player Two ");
            }

            Console.ReadLine();
        }

    }
}
