using System;

namespace noughtsAndCrosses
{
    class Program 
    {
        private enum BoardState 
        {
            // complete this enum with all the possible states of a noughts and crosses board (there's more than 3)
            INITIAL, IN_PLAY, NOUGHTS_WIN, CROSSES_WIN, DRAW
        }
        private static BoardState GetStateOfBoard(string board) 
        {
            // complete this method so that it returns the correct board state
            if(board == "_________") 
            {
                Console.WriteLine("The game has not yet started");
                return BoardState.INITIAL;
            }

            char a = board[0];
            char b = board[1];
            char c = board[2];
            char d = board[3];
            char e = board[4];
            char f = board[5];
            char g = board[6];
            char h = board[7];
            char i = board[8];

            string X = "XXX";
            string O = "OOO";

            Console.WriteLine(a);

            Console.WriteLine(a+b+c);


            if(X.Equals(a+b+c))
            {
                return BoardState.CROSSES_WIN;
            }

            return BoardState.NOUGHTS_WIN;
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
