using Raven.Client.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilligerElectronics.BudgetPlanner.Core;

namespace VilligerElectronics.BudgetPlanner.DataStore
{
    public class DataAccess : IDataAccess
    {
        public DataAccess(IDocumentStore store)
        {
            _store = store;
        }   

        private IDocumentStore _store;

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

        public IQueryable<T> Query2<T>()
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<T>();
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
