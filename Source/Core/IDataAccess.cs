using BudgetPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilligerElectronics.BudgetPlanner.Core
{
    public interface IDataAccess
    {
        List<T> Query<T>();

        Task<List<T>> QueryAsync<T>();

        IQueryable<T> Query2<T>();

        T Query<T>(string id);

        void Store<T>(T document);

        void Remove<T>(string id);

        Task<Balance?> GetClosestBalance(DateOnly today);
    }
}
