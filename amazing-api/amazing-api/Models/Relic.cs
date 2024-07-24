using System.Runtime.CompilerServices;

namespace amazing_api.Models
{
    public class Relic
    {   
        public Relic(RelicSection? relicSection, RelicItem? relicItem, RelicRarity? relicRarity, RelicCurrentStat mainStat, List<RelicCurrentStat> subStatList, List<RelicItemPhoto> relicPhoto)
        {
            this.Id = 0;
            this.Level  = 0;
            this.Exp = 0;
            this.RelicSectionID = relicSection?.Id ?? 0;
            this.RelicSection = relicSection?.RelicName ?? string.Empty;
            this.RelicItem = relicItem;
            this.RelicItemname = relicItem?.ItemName ?? "-";
            this.RelicRarityID = relicRarity?.Id ?? 0;
            this.RelicRarity = relicRarity?.RarityName ?? string.Empty;
            this.MainStat = mainStat;
            this.SubStatList = subStatList;
            this.RelicPhotoID = relicPhoto?[0].Id ?? 0;
            this.RelicPhoto = relicPhoto?[0].RelicLinkPhoto ?? string.Empty;            
        }

        public int Id { get; set; } = 0;
        public int Level { get; set; } = 0;
        public int Exp { get; set; }

        public string RelicSection { get; set; }
        public string RelicRarity {  get; set; } 
        public string RelicItemname { get; set; } 
        public string RelicPhoto { get; set; }
        public int RelicSectionID {  get; set; }
        public int RelicRarityID { get; set; }
        public int RelicPhotoID { get; set; }


        public RelicCurrentStat MainStat { get; set; }
        public List<RelicCurrentStat>? SubStatList { get; set; } 
        public RelicItem? RelicItem { get; set; }
    }
}
