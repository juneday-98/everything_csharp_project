using amazing_api.Models;
 
namespace amazing_api.Services
{
    public class RelicsService
    {
        public RelicsService() { }
        public RelicsService(string name) { }
        
        public Relic GetRelic()
        {
            Relic relic = new Relic();
            
            try
            {
                using (HsrContext context = new HsrContext())
                {
                    var relicSection = context.RelicSections.Where(p => p.Useable == true).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    var relicItem = context.RelicItems.Where(p => p.RelicId == relicSection.Id).FirstOrDefault();
                    var relicRarity = context.RelicRarities.OrderBy(p => Guid.NewGuid()).ThenByDescending(p => p.Percent).FirstOrDefault();
                    var relicAvailabilityStats = context.RelicAvailabilityStats.Where(p => p.RelicId == relicSection.Id && p.Usable == true).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    var relicStat = context.RelicStats.Where(p => p.Id == relicAvailabilityStats.RelicStatId && p.Usable == true).FirstOrDefault();                    
                    var relicMainValue = context.RelicMainValues.Where(p=> p.RelicRarityId == relicRarity.Id && p.RelicStatId == relicStat.Id).FirstOrDefault() ?? null;
                   
                    var MrelicSubStat = (from subValue in context.RelicSubValues
                                         join stat in context.RelicStats on subValue.RelicStatId equals stat.Id
                                         where subValue.RelicRarityId == relicRarity.Id
                                         select new
                                         {
                                              SubValue = subValue.Value,
                                              StatName = stat.StatName,
                                              StatType = stat.DateType,
                                              StatUnit = stat.Unit,
                                         }).ToList();
                    
                    var relicPhoto = (from item in context.RelicItems
                              join photo in context.RelicItemPhotos on item.Id equals photo.Id
                              where photo.Usable == true
                              select photo).Take(1).ToList();

                    RelicCurrentStat mainStat = new RelicCurrentStat
                    {
                        Id = 0,
                        StatName = relicStat?.StatName ?? "-",
                        StateType = "main",
                        StatValue = relicMainValue?.Base ?? 0,
                        FormatValue = relicStat?.DateType ?? "%f",
                        UnitValue = relicStat?.Unit ?? "",
                    };

                    // wait for utils
                    Random random = new Random();
                    var numOfSubStat = random.Next(relicRarity?.MinSubStat ?? 0, relicRarity?.MaxSubStat ?? 0);
                    var subStatList = new List<RelicCurrentStat>();

                    MrelicSubStat.RemoveAll(e => e.StatName == relicStat?.StatName);

                    //get numOfSubStat
                    for (int i = 0; i < numOfSubStat; i++) 
                    {
                        int index = random.Next(0, MrelicSubStat.Count);

                        RelicCurrentStat subStat = new RelicCurrentStat
                        {
                            Id = 0,
                            StatName = MrelicSubStat[index]?.StatName ?? "-",
                            StateType = "sub",
                            StatValue = MrelicSubStat[index]?.SubValue ?? 0,
                            FormatValue = MrelicSubStat[index].StatType ?? "%f",
                            UnitValue = MrelicSubStat[index]?.StatUnit ?? "",
                        };
                        //remove exist sub-stat
                        MrelicSubStat.RemoveAll(e => e.StatName == MrelicSubStat[index]?.StatName);

                        //add sub to list
                        subStatList.Add(subStat);
                    }
                                   
                    relic.Level = 1;
                    relic.relicSection = relicSection?.RelicName ?? string.Empty;
                    relic.RelicItem = relicItem;
                    relic.relicItemname = relicItem?.ItemName ?? "-";
                    relic.relicRarity = relicRarity?.RarityName ?? string.Empty;
                    relic.MainStat = mainStat;
                    relic.SubStatList = subStatList;
                    relic.RelicPhoto = relicPhoto[0].RelicLinkPhoto ?? string.Empty;

                    return relic;
                }
            } 
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        
    }
}
