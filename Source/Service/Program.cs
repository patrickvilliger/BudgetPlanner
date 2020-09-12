using System;
using VilligerElectronics.BudgetPlanner.Service;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bs = new Bootstrapper();

            bs.Run();

            Console.ReadLine();
        }
    }
}
