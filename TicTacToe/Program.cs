namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.displayBoard();
            for (int i = 0; i < 9; i++)
            {
                int st = game.NextMove();
                Console.Clear();
                game.displayBoard();

                if (st != -1)
                {
                    Console.WriteLine("Player {0} is the winner", st);
                    return;
                }   
                
            }

        }
    }
}
