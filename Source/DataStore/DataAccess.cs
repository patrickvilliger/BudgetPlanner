using BudgetPlanner.Domain.Entities;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilligerElectronics.BudgetPlanner.Core;

namespace VilligerElectronics.BudgetPlanner.DataStore
{
    public class DataAccess : IDataAccess
    {
        private IDocumentStore _store;

        public DataAccess(IDocumentStore store)
        {
            _store = store;
        }   

        public async Task<List<T>> QueryAsync<T>()
        {
            using (var session = _store.OpenAsyncSession())
            {
                return await session.Query<T>().ToListAsync();
            }
        }

        public async Task<Balance?> GetClosestBalance(DateOnly today)
        {
            using (var session = _store.OpenAsyncSession())
            {
                var resultList = await session.Query<Balance>()
                              .Where(b => b.Date < today)
                              .OrderByDescending(x => x.Date)
                              .ToListAsync();

                return resultList.FirstOrDefault();
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
