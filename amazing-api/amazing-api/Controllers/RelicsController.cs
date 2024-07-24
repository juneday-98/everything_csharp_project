using amazing_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace amazing_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelicsController : ControllerBase
    {
        [HttpGet("/Random")]
        public IActionResult RandomRelic()
        {
            RelicsService relicsService = new RelicsService();
            return Ok(relicsService.GetRelic());
        }

        

        [HttpPost("/Level")]        
        public IActionResult UpgradeLevel([FromBody] UpLevelReqDto uplevelDto)
        {
            RelicsService relicsService = new RelicsService();
            return Ok(relicsService.UpdateRelicExp());
        }


        public class UpLevelReqDto
        {
            [Required]             
            public int RelicId { get; set; }
            public int AmountExp { get; set; } = 0;
        }

    }
}
