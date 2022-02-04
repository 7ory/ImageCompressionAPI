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

        }
    }
}
