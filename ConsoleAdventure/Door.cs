using System;

namespace ConsoleAdventure
{
    public class Door
    {
        public readonly string Name;
        public readonly string OpenDescription;
        public readonly string ClosedDescription;
        public readonly Direction Direction;

        private bool _open;

        public Door(string name, string openDesc, string closeDesc, bool state, Direction direction)
        {
            Name = name;
            OpenDescription = openDesc;
            ClosedDescription = closeDesc;
            _open = state;
            Direction = direction;
        }

        public bool Opened => _open;

        public void Open()
        {
            if (_open)
                Console.WriteLine($"The {Name} is already opened.");
            else
                Console.WriteLine($"You open the {Name}");

            _open = true;
        }
        
        public void Close()
        {
            if (!_open)
                Console.WriteLine($"The {Name} is already closed.");
            else
                Console.WriteLine($"You close the {Name}");

            _open = false;
        }

        public void Print()
        {
            Console.WriteLine(_open ? OpenDescription : ClosedDescription);
        }
    }
}
