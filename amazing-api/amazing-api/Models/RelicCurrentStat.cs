namespace amazing_api.Models
{
    public class RelicCurrentStat
    { 
        public int Id { get; set; } = 0;
        public string StatName { get; set; }
        public string StatType{ get; set; }
        public double StatValue { get; set; }
        public string FormatValue { get; set; }
        public string UnitValue { get; set; }
 
    }
}
