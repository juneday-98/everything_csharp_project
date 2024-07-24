using amazing_api.Models;
 
namespace amazing_api.Services
{
    public class RelicsService
    {
        public RelicsService() { }
        public RelicsService(string name) { }
        
        public Relic GetRelic()
        {
            
            try
            {
                RelicSection? relicSection = new RelicSection();
                RelicItem? relicItem = new RelicItem();
                RelicRarity? relicRarity = new RelicRarity();
                RelicAvailabilityStat?  relicAvailabilityStats = new RelicAvailabilityStat();
                RelicStat? relicStat = new RelicStat();
                RelicMainValue? relicMainValue = new RelicMainValue();
                List<RelicItemPhoto>? relicPhoto = new List<RelicItemPhoto>();
                List<RelicSubStat> MrelicSubStat = new List<RelicSubStat>();


                using (HsrContext context = new HsrContext())
                {
                    relicSection = context.RelicSections.Where(p => p.Useable == true).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    relicItem = context.RelicItems.Where(p => p.RelicId == relicSection.Id).FirstOrDefault();
                    relicRarity = context.RelicRarities.OrderBy(p => Guid.NewGuid()).ThenByDescending(p => p.Percent).FirstOrDefault();
                    relicAvailabilityStats = context.RelicAvailabilityStats.Where(p => p.RelicId == relicSection.Id && p.Usable == true).OrderBy(p => Guid.NewGuid()).FirstOrDefault();
                    relicStat = context.RelicStats.Where(p => p.Id == relicAvailabilityStats.RelicStatId && p.Usable == true).FirstOrDefault();                    
                    relicMainValue = context.RelicMainValues.Where(p=> p.RelicRarityId == relicRarity.Id && p.RelicStatId == relicStat.Id).FirstOrDefault() ?? null;

                    relicPhoto = (from item in context.RelicItems
                                  join photo in context.RelicItemPhotos on item.Id equals photo.Id
                                  where photo.Usable == true
                                  select photo).Take(1).ToList();

                    MrelicSubStat = (from subValue in context.RelicSubValues
                                         join stat in context.RelicStats on subValue.RelicStatId equals stat.Id
                                         where subValue.RelicRarityId == relicRarity.Id
                                         select new RelicSubStat { SubValue = subValue, Stat = stat }).ToList();                   


                }

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

                MrelicSubStat.RemoveAll(e => e.Stat?.StatName == relicStat?.StatName);

                //get numOfSubStat
                for (int i = 0; i < numOfSubStat; i++)
                {
                    int index = random.Next(0, MrelicSubStat.Count);

                    RelicCurrentStat subStat = new RelicCurrentStat
                    {
                        Id = 0,
                        StatName = MrelicSubStat[index]?.Stat?.StatName ?? "-",
                        StateType = "sub",
                        StatValue = MrelicSubStat[index]?.SubValue?.Value ?? 0,
                        FormatValue = MrelicSubStat[index]?.Stat?.DateType ?? "%f",
                        UnitValue = MrelicSubStat[index]?.Stat?.Unit ?? ""
                    };
                    //remove exist sub-stat
                    MrelicSubStat.RemoveAll(e => e.Stat?.StatName == MrelicSubStat[index]?.Stat?.StatName);

                    //add sub to list
                    subStatList.Add(subStat);
                }

                Relic relic = new Relic(relicSection, relicItem, relicRarity, mainStat, subStatList, relicPhoto);

                return relic;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }              
    }
}
