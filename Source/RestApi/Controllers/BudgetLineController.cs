using DataStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Unity;

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
        public string Get()
        {
            return "Dummy";
        }
    }
}
