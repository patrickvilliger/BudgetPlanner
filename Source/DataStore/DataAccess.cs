using Microsoft.Extensions.Options;
using NLog;
using Raven.Client.Documents;
using Raven.Embedded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilligerElectronics.BudgetPlanner.DataStore.Interfaces;

namespace VilligerElectronics.BudgetPlanner.DataStore
{
    public class DataAccess : IDataAccess
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
        private IDocumentStore _store;

        public DataAccess(IOptions<DbSettings> settingsAccessor)
        {
            var serverOptions = new ServerOptions()
            {
                ServerUrl = settingsAccessor.Value.ServerUrl,
                DataDirectory = settingsAccessor.Value.DataDirectory,
                FrameworkVersion = "6.0.0"
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
            catch (Exception e)
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

        public async Task<List<T>> QueryAsync<T>()
        {
            using (var session = _store.OpenAsyncSession())
            {
                return await session.Query<T>().ToListAsync();
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

        public void Remove<T>(string id)
        {
            using (var session = _store.OpenSession())
            {
                session.Delete(id);
                session.SaveChanges();
            }
        }
    }
}
