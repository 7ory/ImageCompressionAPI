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

            //string inputPdfPath = @"C:\Output-PDFs\";
            string outputPath = @"C:\Output-PDFs\Output images";
            string[] inputPdfPath = Directory.GetFiles(@"C:\Output-PDFs", "*.pdf");
            int PageNumber = 1;

   
            foreach (var item in inputPdfPath)
            {
                string outImageName = Path.GetFileNameWithoutExtension(item);
                outImageName = outImageName + "_" + PageNumber.ToString() + "_.png";


                GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.Png256);
                dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
                dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
                dev.ResolutionXY = new GhostscriptImageDeviceResolution(290, 290);
                dev.InputFiles.Add(item);
                dev.Pdf.FirstPage = PageNumber;
                dev.Pdf.LastPage = PageNumber;
                dev.CustomSwitches.Add("-dDOINTERPOLATE");
            
                // dev.OutputPath = Server.MapPath(@"~/tempImages/" + outImageName);
                dev.OutputPath = Path.Combine(outputPath, outImageName);
                dev.Process();
            }





            return Ok();
        }


    }
}