using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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

            var ResizePercentage = 0.6;

            foreach (var item in filepaths)
            {

                FileInfo file = new FileInfo(item);

                Bitmap img = new Bitmap(item);

                var imageHeight = img.Height*ResizePercentage;
                var imageWidth = img.Width* ResizePercentage;

               

                using (var image = new MagickImage(item))
                {

                    var size = new MagickGeometry((int)imageWidth, (int)imageHeight);

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
