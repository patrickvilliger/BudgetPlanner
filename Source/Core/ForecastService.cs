﻿using BudgetPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VilligerElectronics.BudgetPlanner.Core
{
    public class ForecastService
    {
        private readonly IBudgetRepository budgetRepo;
        private readonly IBalanceRepository balanceRepo;

        public ForecastService(IBudgetRepository budgetRepo, IBalanceRepository balanceRepo)
        {
            this.budgetRepo = budgetRepo;
            this.balanceRepo = balanceRepo;
        }

        public async Task<List<ForecastPosition>> CreateForecast(DateOnly today)
        {
            var latestBalanceRecord = await balanceRepo.GetClosestBalance(today);
            if (latestBalanceRecord == null)
            {
                return new List<ForecastPosition> { };
            }

            throw new NotImplementedException();

            /*var budgetPositions = dataAccess.Query2<BudgetPosition>().Where(b => b.DueDate > latestBalanceRecord.Date).OrderBy(x => x.DueDate).ToList();
            
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
                    Date = budgetPosition.DueDate
                };
            }

            return forecast;
            */
        }
    }
}
