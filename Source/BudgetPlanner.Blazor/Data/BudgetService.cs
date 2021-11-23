using VilligerElectronics.BudgetPlanner.Core.Budget;
using VilligerElectronics.BudgetPlanner.DataStore.Interfaces;

namespace BudgetPlanner.Blazor.Data
{
    public class BudgetService
    {
        private readonly IDataAccess dataAccess;

        public BudgetService(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Task<List<BudgetPosition>> GetAllBudgetPositions()
        {
            return dataAccess.QueryAsync<BudgetPosition>();
        }

        public void StoreBudgetPosition(BudgetPosition pos)
        {
            dataAccess.Store<BudgetPosition>(pos);
        }
    }
}
