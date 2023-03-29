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

    }

    
}
