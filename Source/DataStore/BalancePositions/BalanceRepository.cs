using BudgetPlanner.Domain.Entities;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilligerElectronics.BudgetPlanner.Core;

namespace VilligerElectronics.BudgetPlanner.DataStore.BalancePositions
{
    public class BalanceRepository : IBalanceRepository
    {
        private IDocumentStore _store;

        public BalanceRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<List<Balance>> QueryAsync()
        {
            using (var session = _store.OpenAsyncSession())
            {
                var result = await session
                    .Query<BalanceDb>()
                    .ToListAsync();

                return result
                    .Select(x => x.Map())
                    .ToList();
            }
        }

        public void Store(Balance document)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(document.Map());
                session.SaveChanges();
            }
        }

        public void Remove(string id)
        {
            using (var session = _store.OpenSession())
            {
                session.Delete(id);
                session.SaveChanges();
            }
        }

        public async Task<Balance?> GetClosestBalance(DateOnly today)
        {
            var refDate = today.ToDateTime(TimeOnly.MinValue);

            using (var session = _store.OpenAsyncSession())
            {
                var resultList = await session.Query<BalanceDb>()
                              .Where(b => b.Date < refDate)
                              .OrderByDescending(x => x.Date)
                              .ToListAsync();

                return resultList.FirstOrDefault()?.Map();
            }
        }
    }
}
