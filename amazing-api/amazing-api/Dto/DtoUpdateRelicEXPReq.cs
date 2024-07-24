using amazing_api.Models;
using System.ComponentModel.DataAnnotations;

namespace amazing_api.Dto
{
    public class DtoUpdateRelicEXPReq
    {

        public DtoUpdateRelicEXPReq(Relic inputRelic, int inputExp)
        {
            this.CurrentRelice = inputRelic;
            this.exp = inputExp;
        }
        
        [Required(ErrorMessage = "Relic is required.")]
        public Relic CurrentRelice { get; set; }
        
        
        [Required(ErrorMessage = "Exp amount is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Exp must be a positive integer.")]
        public int exp { get; set; }

    }
}
