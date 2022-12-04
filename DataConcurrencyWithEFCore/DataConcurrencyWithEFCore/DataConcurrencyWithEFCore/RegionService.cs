using DataConcurrencyWithEFCore.DataLayer;

namespace DataConcurrencyWithEFCore;

public class RegionService
{
    public void Execute()
    {
        var regionOneRepository = new RegionRepository();
        var regionTwoRepository = new RegionRepository();

        var foundedRegionOne = regionOneRepository.Get(1);
        var foundedRegionTwo = regionTwoRepository.Get(1);

        Console.WriteLine(foundedRegionOne.RowDateNew);
        foundedRegionOne.RegionDescription = "Eastern 1";
        foundedRegionTwo.RegionDescription = "Eastern 3";
        
        regionOneRepository.Update(foundedRegionOne);
        
        regionTwoRepository.Update(foundedRegionTwo);
    }
}