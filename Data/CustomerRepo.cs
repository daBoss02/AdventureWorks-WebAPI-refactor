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


        public Customer CreateCustomer(Customer customer)
        {
            Customer newCustomer = new Customer
            {
                Title = customer.Title ?? string.Empty,
                FirstName = customer.FirstName ?? string.Empty,
                MiddleName = customer.MiddleName ?? string.Empty,
                LastName = customer.LastName ?? string.Empty,
                EmailAddress = customer.EmailAddress ?? string.Empty,
                Phone = customer.Phone ?? string.Empty,
                Suffix = customer.Suffix ?? string.Empty,
                CompanyName = customer.CompanyName ?? string.Empty,
                SalesPerson = customer.SalesPerson ?? string.Empty,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };
          _context.Add(newCustomer);
          _context.SaveChanges();
          return newCustomer;
        }
        public Customer UpdateCustomer(Customer inputCustomer, int id)
        {
            Customer? customerToUpdate = _context.Customers.Find(id);
            if (customerToUpdate == null)
            {
                CreateCustomer(inputCustomer);
                return inputCustomer;
            }
            else
            {
                if (!String.IsNullOrEmpty(inputCustomer.FirstName))
                {
                    customerToUpdate.FirstName = inputCustomer.FirstName;
                }
                if (!String.IsNullOrEmpty(inputCustomer.MiddleName))
                {
                    customerToUpdate.MiddleName = inputCustomer.MiddleName;
                }
                if (!String.IsNullOrEmpty(inputCustomer.LastName))
                {
                    customerToUpdate.LastName = inputCustomer.LastName;
                }
                if (!String.IsNullOrEmpty(inputCustomer.Title))
                {
                    customerToUpdate.Title = inputCustomer.Title;
                }
                if (!String.IsNullOrEmpty(inputCustomer.Suffix))
                {
                    customerToUpdate.Suffix = inputCustomer.Suffix;
                }
                if (!String.IsNullOrEmpty(inputCustomer.CompanyName))
                {
                    customerToUpdate.CompanyName = inputCustomer.CompanyName;
                }
                if (!String.IsNullOrEmpty(inputCustomer.EmailAddress))
                {
                    customerToUpdate.EmailAddress = inputCustomer.EmailAddress;
                }
                if (!String.IsNullOrEmpty(inputCustomer.Phone))
                {
                    customerToUpdate.Phone = inputCustomer.Phone;
                }
                if (!String.IsNullOrEmpty(inputCustomer.SalesPerson))
                {
                    customerToUpdate.SalesPerson = inputCustomer.SalesPerson;
                }


                customerToUpdate.ModifiedDate = DateTime.Now;

                _context.Update(customerToUpdate);
                _context.SaveChanges();
                return customerToUpdate;
            }
        }
    }
}
