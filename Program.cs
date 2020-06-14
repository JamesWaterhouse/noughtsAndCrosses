using System;

namespace noughtsAndCrosses
{
    class Program 
    {
        private enum BoardState 
        {
            INITIAL, IN_PLAY, NOUGHTS_WIN, CROSSES_WIN, DRAW, INVALID, CHEAT
        }

        //Takes a winning 3-in-a-row and checks if it is X or O
        private static BoardState CheckWinner(char winner)
        {
            if(winner == 'X') 
            {
                Console.WriteLine("Crosses Win!");
                return BoardState.CROSSES_WIN;
            }
            
            Console.WriteLine("Noughts Win!");
            return BoardState.NOUGHTS_WIN;
            
        }
        // Takes in a result string and checks validity and winning combinations. Returns the state of the game.
        private static BoardState GetStateOfBoard(string board) 
        {
        
            // check rows for 3-in-a-row and returns the correct board state if found
            int r;
            for (r = 0; r < 7; r += 3)
            {
               if(board[0+r].Equals(board[1+r]) && board[1+r].Equals(board[2+r]) && !board[0+r].Equals('_'))
               {
                   return CheckWinner(board[0+r]);
               }
            }

            //check columns for 3-in-a-row and returns the correct board state if found
            int c;
            for (c = 0; c < 3; c++)
            {
               if(board[0+c].Equals(board[3+c]) && board[3+c].Equals(board[6+c]) && !board[0+c].Equals('_'))
               {
                   return CheckWinner(board[0+c]);
               }
            }

            // check diagonals for 3-in-a-row and returns the correct board state if found
            if(board[0].Equals(board[4]) && board[4].Equals(board[8]) && !board[0].Equals('_'))
            {
                return CheckWinner(board[0]);
            }
            if(board[2].Equals(board[4]) && board[4].Equals(board[6]) && !board[0].Equals('_'))
            {
                return CheckWinner(board[2]);
            }

            //returns draw if no winning 3-in-a-row found
            return BoardState.DRAW;

        }
        //checks multiple input strings
        static void Main(string[] args) 
        {
            for (int i = 0; i < args.Length; i++)
            {
                System.Console.WriteLine(GetStateOfBoard(args[i]));
            } 
        }
    }
}
