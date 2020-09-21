using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Region.Mediator;
using Region.Mediator.Command;
using Region.Mediator.Query;

namespace Region.Accounting.Controllers
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
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICommandBus commandBus, IQueryBus queryBus)
        {
            _logger = logger;
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        [Route("test")]
        [HttpGet]
        public void Test()
        {
            _commandBus.Handle(new TestCommand());

//            return _queryBus.Handle(new TestQuery("Hello World: "));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
