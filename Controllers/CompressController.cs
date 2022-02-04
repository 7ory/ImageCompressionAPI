using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageCompressionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompressController : ControllerBase
    {

        [HttpGet]
        public IActionResult Compress()
        {
            string[] filepaths = Directory.GetFiles(@"C:\Users\User\Downloads\Images", "*.jpg");

            string outputPath = "C:\\Users\\User\\Downloads\\Images-Output";

            foreach (var item in filepaths)
            {
                using (var image = new MagickImage(item))
                {    
                    var size = new MagickGeometry(480, 2460);

                    size.IgnoreAspectRatio = true;

                    image.Resize(size);

                    string dest = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(item) + "- compressed" + ".jpg");

                    image.Write(dest);

                }
            }
            return Ok();

        }
    }
}
