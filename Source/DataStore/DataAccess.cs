using DataStore.Interfaces;
using NLog;
using Raven.Client.Documents;
using Raven.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStore
{
    public class DataAccess : IDataAccess
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
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
            catch (Exception e)
            {
                Log.Error(e);
            }

            try
            {
                _store = EmbeddedServer.Instance.GetDocumentStore("BudgetPlanner");
            }
            catch(Exception e)
            {
                Log.Error(e);
            }

        }

        public List<T> Query<T>()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<T>().ToList();
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
                session.SaveChanges();
            }
        }
    }
}
