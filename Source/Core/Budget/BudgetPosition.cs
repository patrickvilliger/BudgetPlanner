using System;
using System.Collections.Generic;

namespace VilligerElectronics.BudgetPlanner.Core.Budget
{
    public record BudgetPosition
    {
        public string Description { get; init; }

        public IEnumerable<string> Tags { get; init; }

        public DateTimeOffset DueDate { get; init; }

        public DateTimeOffset BookingDate { get; init; }

        public decimal Ammount { get; init; }

    }
}
