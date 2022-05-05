using Ghostscript.NET;
using Ghostscript.NET.Rasterizer;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Reflection;

namespace ImageCompressionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Convert_PDF_To_JPEGController : ControllerBase
    {

        [HttpGet]
        public IActionResult Convert()
        {

            string inputPdfPath = @"C:\Users\User\Downloads\Images\AccountDetails (1).pdf";
            string outputPath = @"C:\Output-PDFs\Output images";
            int PageNumber;


            return Ok();
        }


    }
}