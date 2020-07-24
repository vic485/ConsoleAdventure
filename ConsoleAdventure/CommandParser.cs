using System;

namespace ConsoleAdventure
{
    public static class CommandParser
    {
        public static void Parse(string commandString)
        {
            if (string.IsNullOrWhiteSpace(commandString))
                return;

            var command = commandString.ToLower().Split(' ');

            switch (command[0])
            {
                case "i":
                case "inv":
                case "inventory":
                    Player.ShowInventory();
                    break;
                case "n":
                case "north":
                    Maze.TryMove(Direction.North);
                    break;
                case "s":
                case "south":
                    Maze.TryMove(Direction.South);
                    break;
                case "e":
                case "east":
                    Maze.TryMove(Direction.East);
                    break;
                case "w":
                case "west":
                    Maze.TryMove(Direction.West);
                    break;
                case "go":
                case "walk":
                case "run":
                    if (command.Length < 2)
                    {
                        Console.WriteLine($"Where are you trying to {command[0]}?");
                        break;
                    }

                    CheckMovement(command[1]);
                    break;
                case "grab":
                case "take":
                    if (command.Length < 2)
                    {
                        Console.WriteLine($"What are you trying to {command[0]}?");
                        break;
                    }

                    Maze.TryTakeItem(command[1]);
                    break;
                case "drop":
                    if (command.Length < 2)
                    {
                        Console.WriteLine($"What are you trying to {command[0]}?");
                        break;
                    }

                    Maze.TryDropItem(command[1]);
                    break;
                case "look":
                    Maze.ViewRoom();
                    break;
                case "open":
                    Maze.TryOpenDoor();
                    break;
                case "close":
                    Maze.TryCloseDoor();
                    break;
                case "exit":
                case "leave":
                case "quit":
                    CheckQuit();
                    break;
                case "help":
                    Console.WriteLine("Movement: go/walk/run [north/east/south/west]");
                    Console.WriteLine("Interact: grab/take/drop [item]");
                    Console.WriteLine("          open");
                    Console.WriteLine("Inventory: i/inv/inventory");
                    Console.WriteLine("Quit game: exit/leave/quit");
                    break;
                default:
                    Console.WriteLine($"I don't understand \"{command[0]}\".");
                    return;
            }
        }

        private static void CheckQuit()
        {
            Console.WriteLine("This will terminate the game, and unsaved progress will be lost. Are you sure?");

            if (Game.GetInput().Equals("yes"))
                Environment.Exit(0);
        }

        private static void CheckMovement(string direction)
        {
            switch (direction)
            {
                case "north":
                    Maze.TryMove(Direction.North);
                    break;
                case "south":
                    Maze.TryMove(Direction.South);
                    break;
                case "east":
                    Maze.TryMove(Direction.East);
                    break;
                case "west":
                    Maze.TryMove(Direction.West);
                    break;
            }
        }
    }
}
