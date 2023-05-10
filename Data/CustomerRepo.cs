using WebApplication1.Models;

namespace AdventureWorks_WebAPI_refactor.Data
{
    public class CustomerRepo
{
    private AdventureWorksLt2019Context _context;
    public CustomerRepo(AdventureWorksLt2019Context context)
    {
        _context = context;
    }

    public ICollection<Customer> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    public Customer GetCustomer(int id)
    {
        return _context.Customers.Find(id);
    }

    public void CreateCustomer(Customer customer)
    {
        _context.Add(customer);
        _context.SaveChanges();

    }
}
}
