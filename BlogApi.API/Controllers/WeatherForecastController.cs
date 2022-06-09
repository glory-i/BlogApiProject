using BlogApi.API.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.API.Controllers
{

    //[Authorize(AuthenticationSchemes ="Bearer")]
    //[Authorize]

    [Authorize(Roles = "User,Admin")]
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
        [Route("weatherforecast")]
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

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("getagain")]
        public string GetAgain()
        {
            string s = "Your name is " + User.Identity.Name + " you are an admin";
            return s;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        [Route("getagain2")]
        public string GetAgain2()
        {
            string s = "You are an ordinary user";
            return s;
        }

    }
}
