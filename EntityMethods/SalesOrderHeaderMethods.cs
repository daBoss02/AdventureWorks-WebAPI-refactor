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

        public static IResult CreateSalesOrderHeader(AdventureWorksLt2019Context db, int salesOrderId, int salesOrderDetailId, int customerId, SalesOrderHeader header)
        {
            try
            {
                SalesOrderDetail salesOrderDetail = db.SalesOrderDetails.FirstOrDefault(sod => sod.SalesOrderId == salesOrderId && sod.SalesOrderDetailId == salesOrderDetailId);
                Customer customer = db.Customers.Find(customerId);
                CustomerAddress customerAddress = db.CustomerAddresses.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                int addressId = 0;

                if (salesOrderDetail == null)
                {
                    return Results.BadRequest();
                }
                
                if (customer == null)
                {
                    return Results.BadRequest();
                }

                if(customerAddress != null)
                {
                    addressId = customerAddress.AddressId;
                }                

                var newSalesOrderHeader = db.SalesOrderHeaders.Add(new SalesOrderHeader
                {
                    RevisionNumber = (byte)(header.RevisionNumber != 0 ? header.RevisionNumber : 0),
                    OrderDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    Status = (byte)(header.Status != 0 ? header.Status : 0),
                    SalesOrderNumber = "SO" + salesOrderDetail.SalesOrderId,
                    PurchaseOrderNumber = header.PurchaseOrderNumber ?? string.Empty,
                    AccountNumber = header.AccountNumber ?? null,
                    CustomerId = customer.CustomerId,
                    ShipToAddressId = addressId,
                    BillToAddressId = addressId,
                    ShipMethod = "CARGO TRANSPORT 5",
                    CreditCardApprovalCode = header.CreditCardApprovalCode ?? null,
                    SubTotal = (decimal)salesOrderDetail.LineTotal,
                    TaxAmt = header.TaxAmt != 0 ? header.TaxAmt : 0,
                    Freight = header.Freight != 0 ? header.Freight : 0,
                    TotalDue = (decimal)salesOrderDetail.LineTotal + (header.TaxAmt != 0 ? header.TaxAmt : 0) + (header.Freight != 0 ? header.Freight : 0),
                    Comment = header.Comment ?? null,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                }) ;

                db.SaveChanges();
                return Results.Ok();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
