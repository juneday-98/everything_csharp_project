using amazing_api.Dto;
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
        public IActionResult UpgradeLevel([FromBody] DtoUpdateRelicEXPReq uplevelDto)
        {
            RelicsService relicsService = new RelicsService();
            try
            {
               
               return Ok(relicsService.UpdateRelicExp(uplevelDto));
            }
            catch (Exception ex) {
                return BadRequest();
            }
            
        }        
    }
}
