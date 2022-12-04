using DataConcurrencyWithEFCore.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataConcurrencyWithEFCore.DataLayer;

public class RegionRepository
{
    public NorthwindDataContext NorthwindDataContext { get; set; }
    
    public RegionRepository()
    {
        this.NorthwindDataContext = new NorthwindDataContext();
    }

    public Region Get(int regionId)
    {
        return this.NorthwindDataContext.Regions.First(p => p.RegionID == regionId);
    }

    public void Update(Region model)
    {
        model.RowDateNew2 = DateTime.Now;
        this.NorthwindDataContext.Regions.Update(model);
        this.NorthwindDataContext.SaveChanges();
    }
}