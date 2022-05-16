using Microsoft.AspNetCore.Mvc;

namespace ImageCompressionAPI.Controllers
{
    public class CompressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
