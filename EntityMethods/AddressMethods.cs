using WebApplication1.Models;

namespace WebApplication1.EntityMethods
{
    public static class AddressMethods
    {
        public static IResult GetAddresses(AdventureWorksLt2019Context db, int maxResults = 100)
        {
            return Results.Ok(db.Addresses
                .Take(maxResults)
                .ToList());
        }
    }
}
