//using DddCqrs.Crud.Domain;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using DddCqrs.Crud.Domain.Generators;

//namespace DddCqrs.Crud.Presentation.Server.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public List<WeatherForecast> Get()
//        {
//            List<WeatherForecast> response = WeatherForecastGenerator.GenerateWeatherForecast();
//            IPAddress userIp = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
//            _logger.LogDebug($"[Request from {userIp}: Serving Get() response: {string.Join("\n", response.ToList())}");
//            return response;
//        }
//    }
//}
