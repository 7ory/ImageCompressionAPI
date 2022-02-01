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
            string[] filePaths = Directory.GetFiles(@"C:\Users\User\Downloads\Images\");

            //string OutputPath = "C:\\Users\\User\\Downloads\\Images-Output\\";
            

            foreach (var item in filePaths)
            {
                using (var image = new MagickImage(item))
                {
                    var size = new MagickGeometry(500, 500);
                    // This will resize the image to a fixed size without maintaining the aspect ratio.
                    // Normally an image will be resized to fit inside the specified size.
                    size.IgnoreAspectRatio = false;

                    image.Resize(size);


                    // Save the result
                    image.Write(item);
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