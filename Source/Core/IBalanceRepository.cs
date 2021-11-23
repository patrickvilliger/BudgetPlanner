using BudgetPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VilligerElectronics.BudgetPlanner.Core
{
    public interface IBalanceRepository
    {
        Task<List<Balance>> QueryAsync();

        void Store(Balance document);

        void Remove(string id);

        Task<Balance?> GetClosestBalance(DateOnly today);
    }
}
