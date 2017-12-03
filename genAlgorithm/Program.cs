using System;

namespace genAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new Gen();
            gen.ShowArray();
            Console.WriteLine("----------------------------------");
            gen.Crossing(0, 2, 6, 7);
            gen.Crossing(1, 3, 8, 9);
            gen.ShowArray();
            Console.WriteLine("----------------------------------");
            gen.Mutation();
            gen.ShowArray();
            Console.WriteLine("----------------------------------");
            gen.ShowMax();
            Console.ReadLine();
        }
    }
}
