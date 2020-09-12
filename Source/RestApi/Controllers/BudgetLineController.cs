using DataStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult Get()
        {
            try
            {
                var budgetLines = _dataAccess.Query<OneTimeBudgetLine>();

                return Ok(budgetLines);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
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
