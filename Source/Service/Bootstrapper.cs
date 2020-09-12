using DataStore;
using DataStore.Interfaces;
using RestApi;
using Unity;

namespace VilligerElectronics.BudgetPlanner.Service
{
    internal class Bootstrapper
    {
        public void Run()
        {
            Container = new UnityContainer();

            Container.RegisterSingleton<IDataAccess, DataAccess>();

            var da = Container.Resolve<IDataAccess>();

            Program.Run(Container);
        }

        public IUnityContainer Container { get; private set; }
    }
}
