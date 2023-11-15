using BalancaDaVidaAPI.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BalancaDaVidaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;

        public FoodController(ILogger<FoodController> logger)
        {
            _logger = logger;
        }

        [HttpGet("All")]
        public ActionResult<string> GetAll()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(FoodsFactory.CreateFoodList()));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now:dd/MM/yyyy} - {e.Message}");

                return BadRequest(e.Message);
            }
        }

        [HttpGet("All/{numberOfFoods}")]
        public ActionResult<string> GetAll(int numberOfFoods)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(FoodsFactory.CreateFoodList(numberOfFoods)));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now:dd/MM/yyyy} - {e.Message}");

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ById/{ID}")]
        public ActionResult<string> GetByID(int ID)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(FoodsFactory.GetById(ID)));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now:dd/MM/yyyy} - {e.Message}");

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ByName/{name}")]
        public ActionResult<string> GetByName(string name)
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(FoodsFactory.GetByName(name)));
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now:dd/MM/yyyy} - {e.Message}");

                return BadRequest(e.Message);
            }
        }
    }
}
