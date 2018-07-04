using System;

namespace Demo
{
    class Program
    {
        static void Work(ScaleClosure scale)
        {
            int y = scale.Scale(5);
            Console.WriteLine(y);
        }

        class ScaleClosure
        {
            public int environment;
            public int Scale(int arg) => this.environment * arg;
        }

        static void Main(string[] args)
        {
            var scale = new ScaleClosure() {environment = 2};

            scale.environment = 3;
            Work(scale);
            Console.ReadLine();
        }
    }
}
