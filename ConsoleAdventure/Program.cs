using System;

namespace ConsoleAdventure
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Clear();
            var game = new Game();
            game.Run();
        }
    }
}
