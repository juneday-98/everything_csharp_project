using amazing_api.Services;
using Aspose.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace amazing_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsposePDFController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            AsposePDFService service = new AsposePDFService();

            return Ok(service.GeneratePDF());
        }
    }
}
