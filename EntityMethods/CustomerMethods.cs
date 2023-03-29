using System.Net.Mail;
using System.Numerics;
using WebApplication1.Models;
namespace WebApplication1.EntityMethods
{
    public  static class CustomerMethods
    {
        public static IResult GetCustomers(AdventureWorksLt2019Context db,int maxResults = 100)
        {
            return Results.Ok(db.Customers.Take(maxResults).ToList());
        }

        public static IResult GetCustomerById(AdventureWorksLt2019Context db,int id)
        {
            Customer customer = db.Customers.Find(id);

            if(customer == null)
            {
                return Results.BadRequest();
            }
            else
            {
                return Results.Ok(customer);
            }
        }
        public static IResult DeleteCustomer(AdventureWorksLt2019Context db, int id)
        {
            Customer customer = db.Customers.Find(id);
            

            if (customer == null)
            {
                return Results.BadRequest();
               
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult CreateCustomer(AdventureWorksLt2019Context db, Customer inputCustomer)
        {
            try
            {
                var newCustomer = db.Customers.Add(new Customer
                {
                    Title = inputCustomer.Title ?? string.Empty,
                    FirstName = inputCustomer.FirstName ?? string.Empty,
                    MiddleName = inputCustomer.MiddleName ?? string.Empty,
                    LastName = inputCustomer.LastName ?? string.Empty,
                    EmailAddress = inputCustomer.EmailAddress ?? string.Empty,
                    Phone = inputCustomer.Phone ?? string.Empty,
                    Suffix = inputCustomer.Suffix ?? string.Empty,
                    CompanyName = inputCustomer.CompanyName ?? string.Empty,
                    SalesPerson = inputCustomer.SalesPerson ?? string.Empty,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                });

                db.SaveChanges();
                return Results.Ok(newCustomer.Entity);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult UpdateCustomer(AdventureWorksLt2019Context db, int id, Customer inputCustomer)
        {
            try
            {
                Customer customerToUpdate = db.Customers.Find(id);

                if(customerToUpdate == null)
                {
                    var newCustomer = db.Customers.Add(new Customer
                    {
                        Title = inputCustomer.Title ?? string.Empty,
                        FirstName = inputCustomer.FirstName ?? string.Empty,
                        MiddleName = inputCustomer.MiddleName ?? string.Empty,
                        LastName = inputCustomer.LastName ?? string.Empty,
                        EmailAddress = inputCustomer.EmailAddress ?? string.Empty,
                        Phone = inputCustomer.Phone ?? string.Empty,
                        Suffix = inputCustomer.Suffix ?? string.Empty,
                        CompanyName = inputCustomer.CompanyName ?? string.Empty,
                        SalesPerson = inputCustomer.SalesPerson ?? string.Empty,
                        Rowguid = Guid.NewGuid(),
                        ModifiedDate = DateTime.Now
                    });

                    db.SaveChanges();
                    return Results.Ok(newCustomer.Entity);
                }
                else
                {
                    if(!String.IsNullOrEmpty(inputCustomer.FirstName))
                    {
                        customerToUpdate.FirstName = inputCustomer.FirstName;
                    }
                    if(!String.IsNullOrEmpty(inputCustomer.MiddleName))
                    {
                        customerToUpdate.MiddleName = inputCustomer.MiddleName;
                    }
                    if (!String.IsNullOrEmpty(inputCustomer.LastName))
                    {
                        customerToUpdate.LastName = inputCustomer.LastName;
                    }
                    if(!String.IsNullOrEmpty(inputCustomer.Title))
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
                    db.SaveChanges();
                    return Results.Ok(customerToUpdate);            
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static IResult CustomerDetails(AdventureWorksLt2019Context db ,int id)
        {
            var customer = db.CustomerAddresses
                .Select(ca => new
                {
                    CustomerId = ca.CustomerId,
                    NameStyle = ca.Customer.NameStyle,
                    Title = ca.Customer.Title,
                    FirstName = ca.Customer.FirstName,
                    MiddleName = ca.Customer.MiddleName,
                    LastName = ca.Customer.LastName,
                    Suffix = ca.Customer.Suffix,
                    CompanyName = ca.Customer.CompanyName,
                    SalesPerson = ca.Customer.SalesPerson,
                    EmailAddress = ca.Customer.EmailAddress,
                    Phone = ca.Customer.Phone,
                    Rowguid = ca.Customer.Rowguid,
                    ModifiedDate = ca.Customer.ModifiedDate,
                    Addressess = ca.Address
                }).Where(ca => ca.CustomerId == id);

            if (!customer.Any())
            {
                return Results.BadRequest();
            }

            return Results.Ok(customer);
        }

        public static IResult CustomerAddToAddress(AdventureWorksLt2019Context db, int customerId, int addressId)
        {
            try
            {
                Address address = db.Addresses.Find(addressId);
                Customer customer = db.Customers.Find(customerId);

                if (address == null)
                {
                    return Results.BadRequest();
                }
                if (customer == null)
                {
                    return Results.BadRequest();
                }

                var newCustomerAddress = db.CustomerAddresses.Add(new CustomerAddress
                {
                    AddressId = addressId,
                    CustomerId = customerId,
                    AddressType = "Main Office",
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                });

                db.SaveChanges();
                return Results.Ok(newCustomerAddress.Entity);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
