using System;

namespace noughtsAndCrosses
{
    class Program 
    {
        private enum BoardState 
        {
            // complete this enum with all the possible states of a noughts and crosses board (there's more than 3)
            INITIAL, IN_PLAY, NOUGHTS_WIN, CROSSES_WIN, DRAW, WIN
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

            // if((a.Equals(b) && a.Equals(c)) || (d.Equals(e) && d.Equals(f)) || (g.Equals(h) && g.Equals(i)) || (a.Equals(d) && a.Equals(g)) || (b.Equals(e) && b.Equals(h)) || (c.Equals(f) && c.Equals(i)) || (a.Equals(e) && a.Equals(i)) || (g.Equals(e) && g.Equals(c))) {

            //     return BoardState.WIN;
            // }


           
          

            return BoardState.DRAW;
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
