using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int LargestLength = 0;
            var coords = new List<Tuple<int, int>>();

            Console.WriteLine("Enter the number of artists.");
            int artists = Int32.Parse(Console.ReadLine());

            void FindRoots(int currentLength, int index)
            {
                currentLength += (coords[index].Item2 - coords[index].Item1);
                if (currentLength > LargestLength) LargestLength = currentLength;
                for (int i = index; i < coords.Count - 1; i++)
                {
                    if (coords[i + 1].Item1 >= coords[index].Item2) FindRoots(currentLength, i + 1);
                }
            }

            for (int i = 1; i <= artists; i++)
            {
                Console.WriteLine("Enter start and end point for artist {0}", i);
                string userEntry = Console.ReadLine();
                string[] coordinates = userEntry.Split(' ');
                coords.Add(new Tuple<int, int>(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1])));
            }

            coords.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            Console.Clear();
            foreach (var item in coords)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < coords.Count; i++)
            {
                FindRoots(0, i);
            }

            Console.WriteLine(LargestLength);

            Console.ReadLine();
        }
    }
}
