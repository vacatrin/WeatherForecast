using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceDemoCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PersonalWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILoggerPersonal _loggerPersonal;
        public WeatherForecastController(ILoggerPersonal loggerPersonal)
        {
            this._loggerPersonal = loggerPersonal;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var temp = new Random().Next(-20, 55);

            // log in the temperature, using the personal loggerPersonal I make
            _loggerPersonal.LogPers(temp.ToString());

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temp,
                Summary = Summaries[new Random().Next(Summaries.Count)]
            })
            .ToArray();
        }

        [HttpPost("/Summary")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404, Type =typeof(string[]))]
        [ProducesResponseType(400, Type = typeof(List<>))]
        public string[] AddSummary(string summary)
        {
            Summaries.Add(summary);
            _loggerPersonal.LogPers(summary);
            return Summaries.ToArray();
        }
    }
}
