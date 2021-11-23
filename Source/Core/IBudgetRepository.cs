using BudgetPlanner.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VilligerElectronics.BudgetPlanner.Core
{
    public interface IBudgetRepository
    {
        Task<List<BudgetPosition>> QueryAsync();

        void Store(BudgetPosition document);

        void Remove(string id);
    }
}
