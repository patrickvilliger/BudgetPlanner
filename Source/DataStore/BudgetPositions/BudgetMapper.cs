using BudgetPlanner.Domain.Entities;
using System;
using VilligerElectronics.BudgetPlanner.DataStore.BalancePositions;

namespace VilligerElectronics.BudgetPlanner.DataStore.BudgetPositions
{
    internal static class BudgetMapper
    {
        public static BudgetDb Map(this BudgetPosition bal)
        {
            return new BudgetDb
            {
                Id = bal.Id,
                Description = bal.Description,
                DueDate = bal.DueDate.ToDateTime(TimeOnly.MinValue),
                BookingDate = bal.BookingDate.ToDateTime(TimeOnly.MinValue),
                Ammount = bal.Ammount,
                Tags = bal.Tags
            };
        }

        public static BudgetPosition Map(this BudgetDb bal)
        {
            return new BudgetPosition
            {
                Id = bal.Id,
                Description = bal.Description,
                DueDate = DateOnly.FromDateTime(bal.DueDate),
                BookingDate = DateOnly.FromDateTime(bal.BookingDate),
                Ammount = bal.Ammount,
                Tags= bal.Tags
                
            };
        }
    }
}
