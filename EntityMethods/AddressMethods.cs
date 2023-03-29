using System.Reflection.PortableExecutable;
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

        public static IResult GetAddressById(AdventureWorksLt2019Context db, int id)
        {
            Address address = db.Addresses.Find(id);

            if (address == null)
            {
                return Results.BadRequest();
            }
            else
            {
                return Results.Ok(address);
            }
        }

        public static IResult DeleteAddress(AdventureWorksLt2019Context db, int id)
        {
            Address address = db.Addresses.Find(id);

            if (address == null)
            {
                return Results.BadRequest();
            }

            db.Addresses.Remove(address);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult CreateAddress(AdventureWorksLt2019Context db, Address inputAddress)
        {
            try
            {
                var newAddress = db.Addresses.Add(new Address
                {
                    AddressLine1 = inputAddress.AddressLine1 ?? string.Empty,
                    AddressLine2 = inputAddress.AddressLine2 ?? null,
                    City = inputAddress.City ?? string.Empty,
                    StateProvince= inputAddress.StateProvince ?? string.Empty,
                    CountryRegion = inputAddress.CountryRegion ?? string.Empty,
                    PostalCode = inputAddress.PostalCode ?? string.Empty,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                });

                db.SaveChanges();
                return Results.Ok(newAddress.Entity);

            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
