﻿using BudgetPlanner.Domain.Entities;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilligerElectronics.BudgetPlanner.Core;

namespace VilligerElectronics.BudgetPlanner.DataStore.BudgetPositions
{
    public class BudgetRepository : IBudgetRepository
    {
        private IDocumentStore _store;

        public BudgetRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<List<BudgetPosition>> QueryAsync()
        {
            using (var session = _store.OpenAsyncSession())
            {
                var result = await session
                    .Query<BudgetDb>()
                    .ToListAsync();

                return result
                    .Select(x => x.Map())
                    .ToList();
            }
        }

        public void Store(BudgetPosition document)
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

        public async Task<List<BudgetPosition>> GetBudgetAfter(DateOnly today)
        {
            var refDate = today.ToDateTime(TimeOnly.MinValue);
            using (var session = _store.OpenAsyncSession())
            {
                var result = await session
                    .Query<BudgetDb>()
                    .Where(b => b.DueDate > refDate)
                    .OrderBy(x => x.DueDate)
                    .ToListAsync();

                return result
                    .Select(x => x.Map())
                    .ToList();
            }
        }
    }
}
