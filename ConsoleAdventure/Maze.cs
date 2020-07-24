using System;
using System.Linq;

namespace ConsoleAdventure
{
    public class Maze
    {
        private static Room _currentLocation;

        public static void TryMove(Direction direction)
        {
            if (!_currentLocation.MoveLocations.ContainsKey(direction))
            {
                Console.WriteLine("There is no path in that direction.");
                return;
            }

            if (_currentLocation.Door != null && _currentLocation.Door.Direction == direction)
            {
                if (!_currentLocation.Door.Opened)
                {
                    Console.WriteLine($"A {_currentLocation.Door.Name} blocks your path. (Perhaps open it first?)");
                    return;
                }
            }

            _currentLocation = _currentLocation.MoveLocations[direction];
            _currentLocation.Print();
        }

        public static void TryOpenDoor()
        {
            if (_currentLocation.Door == null)
            {
                Console.WriteLine("There is no door you can open here.");
                return;
            }
            
            _currentLocation.Door.Open();
        }
        
        public static void TryCloseDoor()
        {
            if (_currentLocation.Door == null)
            {
                Console.WriteLine("There is no door you can close here.");
                return;
            }
            
            _currentLocation.Door.Close();
        }

        public static void TryTakeItem(string itemName)
        {
            var item = _currentLocation.Items.FirstOrDefault(x => x.Name.Equals(itemName));

            if (item == null)
            {
                Console.WriteLine($"You see no {itemName} here");
                return;
            }

            _currentLocation.Items.Remove(item);
            Player.Inventory.Add(item);
            Console.WriteLine("(taken)");
        }

        public static void TryDropItem(string itemName)
        {
            var item = Player.Inventory.FirstOrDefault(x => x.Name.Equals(itemName));
            
            if (item == null)
            {
                Console.WriteLine($"You don't have {itemName}");
                return;
            }

            _currentLocation.Items.Add(item);
            Player.Inventory.Remove(item);
            Console.WriteLine("(dropped)");
        }

        public static void ViewRoom()
        {
            _currentLocation.Print(true);
        }

        public static void BuildMaze()
        {
            if (_currentLocation != null)
                return;

            // Create all rooms
            var noh = new Room("North of House", "You stand at the north side of the house.");
            var soh = new Room("South of House", "You stand to the south of a white house, the front door covered in boards and vines.");
            var eoh = new Room("East of House", "You stand to the east of a white house, the windows boarded tight.");
            var woh = new Room("West of House", "You are in a small field, west of a white house, with dense forest all around.");
            
            var kitchen = new Room("Kitchen", "A small kitchen space with a wooden table tucked away in a corner.");
            
            // Link the map
            noh.MoveLocations[Direction.East] = eoh;
            noh.MoveLocations[Direction.West] = woh;
            noh.MoveLocations[Direction.South] = kitchen;

            soh.MoveLocations[Direction.East] = eoh;
            soh.MoveLocations[Direction.West] = woh;

            eoh.MoveLocations[Direction.North] = noh;
            eoh.MoveLocations[Direction.South] = soh;
            
            woh.MoveLocations[Direction.North] = noh;
            woh.MoveLocations[Direction.South] = soh;

            kitchen.MoveLocations[Direction.North] = noh;
            
            // Add items
            var candle = new Item("candle", "A small white candle, the wick blackened from prior use.");
            kitchen.Items.Add(candle);
            
            // Doors
            var window = new Door("window", "A window is in the wall, wide open.", "A window is in the wall, slightly ajar", false, Direction.South);
            noh.Door = window;
            
            // Set start
            _currentLocation = woh;
            _currentLocation.Print();
        }
    }
}
