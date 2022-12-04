using DataConcurrencyWithEFCore.DataLayer;

namespace DataConcurrencyWithEFCore;

public class CustomerService
{
    public void Execute()
    {
        var repository1 = new CustomerRepository();
        var repository2 = new CustomerRepository();

        var customerOne = repository1.Get("ALFKI");
        var customerTwo = repository2.Get("ALFKI");

        customerOne.Region = "denizTest";
        repository1.Update(customerOne);

        customerTwo.Region = "denizTest2";
        repository2.Update(customerTwo);
    }
}