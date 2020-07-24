using System;
using System.Collections.Generic;

namespace ConsoleAdventure
{
    public class Room
    {
        public Dictionary<Direction, Room> MoveLocations = new Dictionary<Direction, Room>();
        public List<Item> Items = new List<Item>();

        public readonly string Name;
        public readonly string Description;

        public Door Door;

        private bool _readOut;

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Print(bool readAgain = false)
        {
            Console.WriteLine(Name);

            if (_readOut && !readAgain)
                return;

            Console.WriteLine(Description);

            if (Items.Count > 0)
            {
                Console.WriteLine($"You see {string.Join(", ", Items)} here");
            }

            Door?.Print();
            _readOut = true;
        }
    }
}
