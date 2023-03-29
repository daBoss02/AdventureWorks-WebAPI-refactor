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

    }

    
}
