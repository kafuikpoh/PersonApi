using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("You called the GET endpoint");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                    {
                        throw new Exception("This is our test exception");
                    }
                    else
                    {
                        _logger.LogInformation("The value of i is {LoopCountValue}", i);
                    }
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "We caught this exception in the Get WeatherForecast call");
            }

            return new string[] { "value1", "Value2" };
        }
    }
}
