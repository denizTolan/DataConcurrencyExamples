// See https://aka.ms/new-console-template for more information

using DataConcurrencyWithEFCore;
using DataConcurrencyWithEFCore.DataLayer;

var dbContext = new NorthwindDataContext();
var customers = dbContext.Customers.ToList();

foreach (var customer in customers)
{
    Console.WriteLine(customer.CompanyName);
}

var customerService = new CustomerService();
// customerService.Execute();

var regionService = new RegionService();
regionService.Execute();