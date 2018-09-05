using System;

namespace DashHashWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"Calculate DashHash for: {arg}");
                Console.WriteLine("Calculated...");
                var dashHashWrapper = new DashHashWrapper();
                var result = dashHashWrapper.CalcDashHash(arg);
                Console.WriteLine($"DashHash is: {dashHashWrapper.ByteArrayToString(result)}");
            }
            Console.ReadKey();
        }
    }
}
