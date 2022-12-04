using System.ComponentModel.DataAnnotations.Schema;

namespace DataConcurrencyWithEFCore.DataLayer.Model;

[Table("Region")]
public class Region
{
    public int RegionID { get; set; }
    public string RegionDescription { get; set; }
    public DateTime RowDate { get; set; }
    public DateTime RowDateNew { get; set; }
    public DateTime? RowDateNew2 { get; set; }
}