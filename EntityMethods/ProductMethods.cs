using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.EntityMethods
{
    public static class ProductMethods
    {
        public static IResult GetProducts(AdventureWorksLt2019Context db, int maxResults = 100)
        {
            return Results.Ok(db.Products.Take(maxResults).ToList());
        }

        public static IResult GetProductById(AdventureWorksLt2019Context db, int id)
        {
            Product product = db.Products.Find(id);

            if(product == null)
            {
                return Results.BadRequest();
            } 
            else
            {
                return Results.Ok(product);
            }
        }

        public static IResult DeleteProduct(AdventureWorksLt2019Context db, int id)
        {
            Product product = db.Products.Find(id);

            if(product == null)
            {
                return Results.BadRequest();
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return Results.NoContent();
        }

        public static IResult ProductDetails(AdventureWorksLt2019Context db, int id) 
        {
            Product product = db.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductModel)
                .ThenInclude(pm => pm.ProductModelProductDescriptions)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(product);
        }
    }
}
