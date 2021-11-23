using BudgetPlanner.Domain.Entities;
using System;
using VilligerElectronics.BudgetPlanner.DataStore.DbModels;

namespace VilligerElectronics.BudgetPlanner.DataStore.BalancePositions
{
    internal static class BalanceMapper
    {
        public static BalanceDb Map(this Balance bal)
        {
            return new BalanceDb
            {
                Id = bal.Id,
                CurrentBalance = bal.CurrentBalance,
                Date = bal.Date.ToDateTime(TimeOnly.MinValue)
            };
        }

        public static Balance Map(this BalanceDb bal)
        {
            return new Balance
            {
                Id = bal.Id,
                CurrentBalance = bal.CurrentBalance,
                Date = DateOnly.FromDateTime(bal.Date)
            };
        }
    }
}
