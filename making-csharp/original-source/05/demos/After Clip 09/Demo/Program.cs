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

        static int GetHashEntry<T>(Element<T>[] set, T value)
        {
            if (object.ReferenceEquals(value, null)) return 0;
            int code = value.GetHashCode();
            int entry = code % set.Length;
            if (entry < 0) entry += set.Length;
            return entry;
        }

        static void Add<T>(Element<T>[] set, T value)
        {
            int entry = GetHashEntry(set, value);
            Console.WriteLine($"Adding {value} to set[{entry}]");

            Element<T> element = new Element<T>()
            {
                Content = value,
                Next = set[entry]
            };
            set[entry] = element;
        }

        static bool Contains<T>(Element<T>[] set, T value)
        {
            int entry = GetHashEntry(set, value);
            Console.WriteLine($"Searching for {value} in set[{entry}]");

            for (Element<T> cur = set[entry]; cur != null; cur = cur.Next)
            {
                if (cur.Content.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {

            Console.ReadLine();
        }
    }
}
