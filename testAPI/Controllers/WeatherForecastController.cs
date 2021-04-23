using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new  Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

  
        [HttpGet("[action]/{id}")]
        public IEnumerable<WeatherForecast> Get(int id)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).Where(a=>a.Id == id)
            .ToArray();
        }
        
        [HttpGet("[action]")]
        public IActionResult Post([FromBody] WeatherForecast data)
        {
            if (data == null || data.Date == DateTime.MinValue || !data.TemperatureC.HasValue || String.IsNullOrEmpty(data.Summary))
                return new JsonResult(new { res = "Not ok" });
            return new JsonResult(new { res="Ok"});
        }


        [HttpGet("[action]")]
        public IActionResult Put([FromBody] WeatherForecast data)
        {
            if (data == null || data.Date == DateTime.MinValue || !data.TemperatureC.HasValue || String.IsNullOrEmpty(data.Summary))
                return new JsonResult(new { res = "Not ok" });
            return new JsonResult(new { res = "Ok" });
        }

    }
}
