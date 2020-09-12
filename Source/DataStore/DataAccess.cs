using DataStore.Interfaces;
using Raven.Client.Documents;
using Raven.Embedded;
using System;

namespace DataStore
{
    public class DataAccess : IDataAccess
    {
        private IDocumentStore _store;

        public DataAccess()
        {

            var serverOptions = new ServerOptions()
            {
                ServerUrl = "http://127.0.0.1:45001",
                DataDirectory = "C:/VilligerElectronics/BudgetPlanner/Database"
            };

            try
            {
                EmbeddedServer.Instance.StartServer(serverOptions);
            }
            catch (Exception)
            {
                var str = "";
            }

            try
            {
                _store = EmbeddedServer.Instance.GetDocumentStore("BudgetPlanner");
            }
            catch(Exception)
            {
                var str = "";
            }

        }

        public T Query<T>(string id)
        {
            using (var session = _store.OpenSession())
            {
                return (T)session.Query<T>(id);
            }
        }

        public void Store<T>(T document)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(document);
            }
        }
    }
}
