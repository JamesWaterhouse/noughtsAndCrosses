﻿using System;

namespace noughtsAndCrosses
{
    class Program 
    {
        private enum BoardState 
        {
            // complete this enum with all the possible states of a noughts and crosses board (there's more than 3)
            INITIAL, IN_PLAY, NOUGHTS_WIN, CROSSES_WIN, DRAW, INVALID, CHEAT
        }

        //Check winner takes a winning 3-in-a-row and checks if X or O is the winner
        private static BoardState CheckWinner(char a)
            {
                if(a == 'X') 
                {
                    Console.WriteLine("Crosses Win!");
                   return BoardState.CROSSES_WIN;
                }
                else
                {
                    Console.WriteLine("Noughts Win!");
                    return BoardState.NOUGHTS_WIN;
                }
            }

        private static BoardState GetStateOfBoard(string board) 
        {
            // complete this method so that it returns the correct board state

            char[] boardArray = board.ToCharArray();
            Console.WriteLine(boardArray);
            
            if(board.Length == 9) 
            {

                char a = board[0];
                char b = board[1];
                char c = board[2];
                char d = board[3];
                char e = board[4];
                char f = board[5];
                char g = board[6];
                char h = board[7];
                char i = board[8];

                int countX = board.Split('X').Length-1;
                int countO = board.Split('O').Length-1;

                if(countX<countO) {
                    Console.WriteLine("Someone is cheating!");
                    return BoardState.CHEAT;
                }

                if(board == "_________") 
                {
                    Console.WriteLine("The game is ready to start");
                    return BoardState.INITIAL;
                }

                if((board[0].Equals(board[1]) && board[1].Equals(board[2])) && !(a.Equals('_')))
                {   
                    return CheckWinner(board[0]);  
                }



                else if (((g.Equals(h) && g.Equals(i)) || (c.Equals(f) && c.Equals(i))) && !(i.Equals('_'))) 
                {
                    return CheckWinner(i); 
                }

                else if(d.Equals(e) && d.Equals(f) && !(d.Equals('_'))) 
                {
                    return CheckWinner(d); 
                }

                else if(b.Equals(e) && b.Equals(h) && !(b.Equals('_'))) 
                {
                    return CheckWinner(b); 
                }

                else if(g.Equals(e) && g.Equals(c) && !(g.Equals('_'))) 
                {
                    return CheckWinner(g); 
                }

                if(board.Contains('_')) 
                {
                    Console.WriteLine("There are moves left to play");
                    return BoardState.IN_PLAY;
                }

                Console.WriteLine("It's a draw!");
                return BoardState.DRAW;   
            }

            Console.WriteLine("The board must be made up of 9 squares");
            return BoardState.INVALID;
        }
        static void Main(string[] args) 
        {
            // leave this main method unchanged
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine(GetStateOfBoard(args[i]));
            } 
        }
    }
}
