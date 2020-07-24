using System;
using System.Collections.Generic;

namespace ConsoleAdventure
{
    public class Player
    {
        public static List<Item> Inventory = new List<Item>();

        public static void ShowInventory()
        {
            Console.WriteLine("In your possession is:");

            if (Inventory.Count == 0)
            {
                Console.WriteLine("Nothing...");
                return;
            }

            foreach (var item in Inventory)
            {
                Console.WriteLine(item);
            }
        }
    }
}
