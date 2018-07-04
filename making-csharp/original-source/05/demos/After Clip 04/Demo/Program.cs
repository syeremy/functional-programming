using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        class Element<T>
        {
            public T Content { get; set; }
            public Element<T> Next { get; set; }
        }

        static void Add(Element<int>[] set, int value)
        {
            int entry = value % set.Length;
            if (entry < 0) entry += set.Length;
            Console.WriteLine($"Adding {value} to set[{entry}]");

            Element<int> element = new Element<int>()
            {
                Content = value,
                Next = set[entry]
            };
            set[entry] = element;
        }

        static bool Contains(Element<int>[] set, int value)
        {
            int entry = value % set.Length;
            if (entry < 0) entry += set.Length;
            Console.WriteLine($"Searching for {value} in set[{entry}]");

            for (Element<int> cur = set[entry]; cur != null; cur = cur.Next)
            {
                if (cur.Content == value)
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            Element<int>[] set = new Element<int>[7];

            Add(set, 22);
            Add(set, 33);
            Add(set, 54);

            if (Contains(set, 33))
            {
                Console.WriteLine("Suspect found!");
            }

            Console.ReadLine();
        }
    }
}
