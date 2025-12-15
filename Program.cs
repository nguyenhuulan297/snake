namespace gamesnake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            Console.ReadKey();
        }
    }
}
