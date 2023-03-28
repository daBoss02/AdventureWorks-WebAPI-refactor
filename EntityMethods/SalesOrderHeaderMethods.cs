using WebApplication1.Models;

namespace WebApplication1.EntityMethods
{
    public static class SalesOrderHeaderMethods
    {
        public static IResult GetSalesOrderHeaders(AdventureWorksLt2019Context db, int maxResults = 100)
        {
            return Results.Ok(db.SalesOrderHeaders.Take(maxResults).ToList());
        }

        public static IResult GetSalesOrderHeaderById(AdventureWorksLt2019Context db, int id)
        {
            SalesOrderHeader orderHeader = db.SalesOrderHeaders.Find(id);

            if (orderHeader == null)
            {
                return Results.BadRequest();
            }
            else
            {
                return Results.Ok(orderHeader);
            }
        }

        public static IResult DeleteSalesOrderHeader(AdventureWorksLt2019Context db, int id)
        {
            SalesOrderHeader orderHeader = db.SalesOrderHeaders.Find(id);

            if (orderHeader == null)
            {
                return Results.BadRequest();

            }
            db.SalesOrderHeaders.Remove(orderHeader);
            db.SaveChanges();
            return Results.NoContent();
        }
    }
}
