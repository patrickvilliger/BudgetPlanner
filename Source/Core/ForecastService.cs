using BudgetPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VilligerElectronics.BudgetPlanner.Core
{
    public class ForecastService
    {
        private readonly IDataAccess dataAccess;

        public ForecastService(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public List<ForecastPosition> CreateForecast(DateOnly today)
        {
            var latestBalanceRecord = dataAccess.Query2<Balance>().Where(b => b.Date < today).Max();
            if (latestBalanceRecord == null)
            {
                return new List<ForecastPosition> { };
            }

            var budgetPositions = dataAccess.Query2<BudgetPosition>().Where(b => b.DueDate > latestBalanceRecord.Date).OrderBy(x => x.DueDate).ToList();
            
            var forecast = new List<ForecastPosition>();
            var currentBalance = latestBalanceRecord.CurrentBalance;
            foreach (var budgetPosition in budgetPositions)
            {
                currentBalance += budgetPosition.Ammount;

                var forecastPos = new ForecastPosition
                {
                    Balance = currentBalance,
                    Change = budgetPosition.Ammount,
                    Description = budgetPosition.Description,
                    Time = budgetPosition.DueDate
                };
            }

            return forecast;
        }
    }
}
