using DataConcurrencyWithEFCore.DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataConcurrencyWithEFCore.DataLayer;

public class CustomerRepository
{
    public NorthwindDataContext NorthwindDataContext { get; set; }
    
    public CustomerRepository()
    {
        this.NorthwindDataContext = new NorthwindDataContext();
    }

    public Customer Get(string customerId)
    {
        return this.NorthwindDataContext.Customers.First(p => p.CustomerID == customerId);
    }

    public void Update(Customer model)
    {
        this.NorthwindDataContext.Customers.Entry(model).State = EntityState.Modified;
        this.NorthwindDataContext.SaveChanges();
    }
}