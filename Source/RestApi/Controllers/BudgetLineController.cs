using DataStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using VilligerElectronics.BudgetPlanner.Core.Budget;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetLineController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public BudgetLineController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public List<OneTimeBudgetLine> Get()
        {
            var budgetLines = _dataAccess.Query<OneTimeBudgetLine>();

            return budgetLines;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OneTimeBudgetLine budgetLine)
        {
            try
            {
                _dataAccess.Store(budgetLine);

                return Ok(budgetLine);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
