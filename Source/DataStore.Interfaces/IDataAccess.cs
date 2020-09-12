namespace DataStore.Interfaces
{
    public interface IDataAccess
    {
        T Query<T>(string id);

        void Store<T>(T document);
    }
}
