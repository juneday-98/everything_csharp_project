using System.Runtime.CompilerServices;

namespace amazing_api.Models
{
    public class Relic
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string relicSection { get; set; }
        public string relicRarity {  get; set; } 
        public string relicItemname { get; set; } 
        public string RelicPhoto { get; set; }
        public RelicCurrentStat MainStat { get; set; }
        public List<RelicCurrentStat>? SubStatList { get; set; } 
        public RelicItem? RelicItem { get; set; }
    }   
}
