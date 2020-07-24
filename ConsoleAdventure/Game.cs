using System;

namespace ConsoleAdventure
{
    public class Game
    {
        public void Run()
        {
            PrintPreamble();
            Maze.BuildMaze();

            while (true)
            {
                CommandParser.Parse(GetInput());
            }
        }

        public static string GetInput()
        {
            Console.WriteLine();
            Console.Write(">");
            return Console.ReadLine();
        }

        private static void PrintPreamble()
        {
            Console.WriteLine("Console Adventure");
            Console.WriteLine("By vic485");
        }
    }
}
