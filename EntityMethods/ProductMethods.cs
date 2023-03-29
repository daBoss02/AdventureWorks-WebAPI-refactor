using System;
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

        public static IResult UpdateProduct(AdventureWorksLt2019Context db, int id, Product inputProduct)
        {
            try
            {
                Product productToUpdate = db.Products.Find(id);

                // if product id is not found create a new product, otherwise update found product
                if (productToUpdate == null)
                {
                    // define new product
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
                else
                {
                    // do checks for all fields except id and rowid
                    if (!String.IsNullOrEmpty(inputProduct.Name))
                        productToUpdate.Name = inputProduct.Name;

                    if (!String.IsNullOrEmpty(inputProduct.ProductNumber))
                        productToUpdate.ProductNumber = inputProduct.ProductNumber;

                    if (!String.IsNullOrEmpty(inputProduct.Color))
                        productToUpdate.Color = inputProduct.Color;

                    if (inputProduct.StandardCost != 0)
                        productToUpdate.StandardCost = inputProduct.StandardCost;

                    if (inputProduct.ListPrice != 0)
                        productToUpdate.ListPrice = inputProduct.ListPrice;

                    if (!String.IsNullOrEmpty(inputProduct.Size))
                        productToUpdate.Size = inputProduct.Size;

                    if (inputProduct.Weight != 0 && inputProduct.Weight != null)
                        productToUpdate.Weight = inputProduct.Weight;

                    if (inputProduct.SellStartDate != null && inputProduct.SellStartDate != new DateTime())
                        productToUpdate.SellStartDate = inputProduct.SellStartDate;

                    if (inputProduct.SellEndDate != null && inputProduct.SellEndDate != new DateTime())
                        productToUpdate.SellEndDate = inputProduct.SellEndDate;

                    // by default set modified date to DateTime.Now
                    productToUpdate.ModifiedDate = DateTime.Now;

                    db.SaveChanges();
                    return Results.Ok(productToUpdate);
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }            
        }
    }
}
