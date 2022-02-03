using ImageMagick;
using Microsoft.AspNetCore.Mvc;

namespace ImageCompressionAPI.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            string[] filepaths = Directory.GetFiles(@"Images");

            string outputPath = "ImagesOutput";

            foreach (var item in filepaths)
            {
                using (var image = new MagickImage(item))
                {
                    var size = new MagickGeometry(500, 500);

                    size.IgnoreAspectRatio = false;

                    image.Resize(size);

                    string dest = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(item) + "- compressed" + ".jpg");

                    image.Write(dest);
                }
            }


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
}