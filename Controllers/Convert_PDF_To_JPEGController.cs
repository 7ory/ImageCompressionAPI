using ImageMagick;
using Microsoft.AspNetCore.Mvc;

namespace ImageCompressionAPI.Controllers
{
    public class Convert_PDF_To_JPEGController : Controller
    {
        public IActionResult Index()
        {
            // Read image from file
            using (var image = new MagickImage("Snakeware.jpg"))
            {
                // Will use the CMYK profile if the image does not contain a color profile.
                // The second profile will transform the colorspace from CMYK to RGB
                image.TransformColorSpace(ColorProfile.USWebCoatedSWOP, ColorProfile.SRGB);

                // Save image as png
                image.Write(SampleFiles.OutputDirectory + "Snakeware.png");
            }
            return View();
        }
    }
}
