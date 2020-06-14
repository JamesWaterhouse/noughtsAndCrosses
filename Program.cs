using System;
using System.Text.RegularExpressions;

namespace noughtsAndCrosses
{
    class Program 
    {
        private enum BoardState 
        {
            INITIAL, IN_PLAY, NOUGHTS_WIN, CROSSES_WIN, DRAW, INVALID, CHEAT
        }

        //Takes a winning player and checks if it is X or O. Returns the state of the game.
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

        // Takes in a board string and checks that it is valid. Returns Boolean.
        private static Boolean BoardValidator(string board)
        {
            // checks that the board contains the correct characters.
            Regex regex = new Regex(@"^[XO_]+$");
            if (!regex.IsMatch(board)) 
            {   
                Console.WriteLine("The board can only contain X, O or _");
                return false;
            }

            // check that a board is the correct size.
            if(board.Length != 9)
            {
                Console.WriteLine("The board must be made of 9 squares");
                return false;
            }

            // if both validators pass, continue.
            return true;
        }

        // Takes in a result string and checks validity and winning combinations. Returns the state of the game.
        private static BoardState GetStateOfBoard(string board) 
        {
            // run validator on board.
            if(!BoardValidator(board))
            {
                return BoardState.INVALID;
            };

            // check if any moves have been made.
            if(board == "_________") 
            {
                Console.WriteLine("The game is ready to start");
                return BoardState.INITIAL;
            }

            // check for validity of numbers of moves of each player.
            int countX = board.Split('X').Length-1;
            int countO = board.Split('O').Length-1;

            if(countX<countO || countX>countO+1) 
            {
                Console.WriteLine("Someone is cheating!");
                return BoardState.CHEAT;
            }
        
            // check rows for 3-in-a-row and returns the correct board state if found.
            int r;
            for (r = 0; r < 7; r += 3)
            {
               if(board[0+r].Equals(board[1+r]) && board[1+r].Equals(board[2+r]) && !board[0+r].Equals('_'))
               {
                   return CheckWinner(board[0+r]);
               }
            }

            //check columns for 3-in-a-row and returns the correct board state if found.
            int c;
            for (c = 0; c < 3; c++)
            {
               if(board[0+c].Equals(board[3+c]) && board[3+c].Equals(board[6+c]) && !board[0+c].Equals('_'))
               {
                   return CheckWinner(board[0+c]);
               }
            }

            // check diagonals for 3-in-a-row and returns the correct board state if found.
            if(board[0].Equals(board[4]) && board[4].Equals(board[8]) && !board[0].Equals('_'))
            {
                return CheckWinner(board[0]);
            }
            if(board[2].Equals(board[4]) && board[4].Equals(board[6]) && !board[0].Equals('_'))
            {
                return CheckWinner(board[2]);
            }

            //After no winner is found, check if the game is finished.
            if(board.Contains('_')) 
            {
                Console.WriteLine("There are moves left to play");
                return BoardState.IN_PLAY;
            }

            //returns draw if no winning 3-in-a-row found and the game was finished within the rules.
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
