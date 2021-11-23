using System.Collections.Generic;

namespace VilligerElectronics.BudgetPlanner.DataStore.Interfaces
{
    public interface IDataAccess
    {
        List<T> Query<T>();

        T Query<T>(string id);

        void Store<T>(T document);
    }
}
