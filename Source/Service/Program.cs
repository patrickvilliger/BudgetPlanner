using NLog;
using System;
using VilligerElectronics.BudgetPlanner.Service;

namespace Service
{
    class Program
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Log.Info("Starting Service");

            var bs = new Bootstrapper();

            bs.Run();

            Console.ReadLine();
        }
    }
}
