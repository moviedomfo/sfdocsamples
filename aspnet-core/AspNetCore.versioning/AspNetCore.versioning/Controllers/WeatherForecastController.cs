using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCore.versioning.Controllers
{
    //https://www.youtube.com/watch?v=ryPo5hYHSzM
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")] 
    public class MastersController : ControllerBase
    {
        private static readonly string[] Summaries_eng = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private static readonly string[] Summaries_ruso = new[]
       {
            "замораживание", "Укрепляющий", "Chilly", "Холодно", "Горячий", "Обжигающий", "Obzhigayushchiy", "Hot", "Iznuryayushchiy", "Myagkiy"
        };
        private readonly ILogger<MastersController> _logger;

        public MastersController(ILogger<MastersController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries_eng[rng.Next(Summaries_eng.Length)]
            })
            .ToArray();
        }

        [MapToApiVersion("2.0")]
        [HttpGet()]
        public IEnumerable<WeatherForecast> Get2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries_ruso[rng.Next(Summaries_ruso.Length)]
            })
            .ToArray();
        }
    }
}
