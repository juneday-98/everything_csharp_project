using amazing_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace amazing_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelicsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            RelicsService relicsService = new RelicsService();
            return Ok(relicsService.GetRelic());
        }
    }
}
