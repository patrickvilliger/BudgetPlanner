using System;

namespace VilligerElectronics.BudgetPlanner.DataStore.BalancePositions
{
    internal class BalanceDb
    {
        public string? Id { get; set; }

        public DateTime Date { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
