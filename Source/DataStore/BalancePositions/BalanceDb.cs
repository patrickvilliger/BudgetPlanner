using System;

namespace VilligerElectronics.BudgetPlanner.DataStore.DbModels
{
    internal class BalanceDb
    {
        public string? Id { get; set; }

        public DateTime Date { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
