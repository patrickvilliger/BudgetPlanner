using System.Collections.Generic;

namespace DataStore.Interfaces
{
    public interface IDataAccess
    {
        List<T> Query<T>();

        T Query<T>(string id);

        void Store<T>(T document);
    }
}
