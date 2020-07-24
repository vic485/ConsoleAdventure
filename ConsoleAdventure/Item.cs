using System.Linq;

namespace ConsoleAdventure
{
    public class Item
    {
        public readonly string Name;
        public readonly string Description;

        private static char[] _vowels = {'a', 'e', 'i', 'o', 'u'};

        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            var prefix = _vowels.Any(x => x.Equals(Name[0])) ? "an " : "a ";
            return prefix + Name;
        }
    }
}
