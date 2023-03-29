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
            var product = db.Products
                .Select(p => new 
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    ProductNumber = p.ProductNumber,
                    Color = p.Color,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    Weight = p.Weight,
                    ProductCategoryName = p.ProductCategory.Name,
                    ProductModelName = p.ProductModel.Name,
                    ProductDescription = p.ProductModel.ProductModelProductDescriptions.Select(pmd => pmd.ProductDescription.Description),
                    SellStartDate = p.SellStartDate,
                    SellEndDate = p.SellEndDate,
                    DiscontinuedDate = p.DiscontinuedDate,
                    ThumbNailPhoto = p.ThumbNailPhoto,
                    ThumbnailPhotoFileName = p.ThumbnailPhotoFileName,
                    Rowguid = p.Rowguid,
                    ModifiedDate = p.ModifiedDate

                }).Where(p => p.ProductId == id);

            if (!product.Any())
            {
                return Results.BadRequest();
            }

            return Results.Ok(product);
        }
    }
}
