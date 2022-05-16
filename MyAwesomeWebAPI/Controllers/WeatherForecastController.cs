using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MyAwesomeWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOptions<MyAwesomeConfiguration> options;
    private readonly MyService myService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<MyAwesomeConfiguration> options, MyService myService)
    {
        _logger = logger;
        this.options = options;
        this.myService = myService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var result = myService.CreateFullName("asdas","AAAAA");

        _logger.LogError("Sorry vole error {name}", options.Value.Name);
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpPost("otherendpoint")]
    public Task<IActionResult> CreateItem([FromBody]WeatherForecast weatherForecast)
    {
        throw new NotImplementedException();
    }
}
