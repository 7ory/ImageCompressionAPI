using ImageMagick;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageCompressionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Convert_JPEG_To_PDFController : ControllerBase
    {
        [HttpGet]
        public IActionResult Convert()
        {
            string[] filepaths = Directory.GetFiles(@"C:\Users\User\Downloads\Images", "*.jpg");

            string outputPath = @"C:\Output-PDFs";

            foreach (var item in filepaths)
            {
                // Read image from file
                using (var image = new MagickImage(item))
                {
                    string dest = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(item) + "- converted" + ".pdf");

                    // Create pdf file with a single page
                    image.Write(dest);
                }

            }

            return Ok();
        }
    }
}
