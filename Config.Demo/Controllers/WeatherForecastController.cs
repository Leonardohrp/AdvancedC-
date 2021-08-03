using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Config.Demo.Controllers
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
        private readonly string version;
        private readonly IOptions<Custom> custom;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            string version,
            IOptions<Custom> custom)
        {
            _logger = logger;
            this.version = version;
            this.custom = custom;
        }

        [HttpGet]
        public string Get()
        {
            return custom.Value.ConfigValue;
        }
    }
}
