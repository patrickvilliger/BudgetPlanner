using System.Collections.Generic;
using System.Threading.Tasks;

namespace VilligerElectronics.BudgetPlanner.DataStore.Interfaces
{
    public interface IDataAccess
    {
        List<T> Query<T>();

        Task<List<T>> QueryAsync<T>();

        T Query<T>(string id);

        void Store<T>(T document);

        void Remove<T>(string id);
    }
}
