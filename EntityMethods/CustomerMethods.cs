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

    }

    
}
