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

        public static IResult CreateProduct(AdventureWorksLt2019Context db, Product inputProduct)
        {
            var newProduct = db.Products.Add(new Product
            {
                Name = inputProduct.Name ?? string.Empty,
                ProductNumber = inputProduct.ProductNumber ?? string.Empty,
                StandardCost = inputProduct.StandardCost != 0 ? inputProduct.StandardCost : 0,
                ListPrice = inputProduct.ListPrice != 0 ? inputProduct.ListPrice : 0,
                SellStartDate = inputProduct.SellStartDate != new DateTime() ? inputProduct.SellStartDate : new DateTime(),
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            });

            db.SaveChanges();
            return Results.Ok(newProduct.Entity);
        }
    }
}
