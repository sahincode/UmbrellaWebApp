
namespace Catalog.API.Products.GetProducts
{
    public record GetProductsRequest(int? PageNumber =1 ,int PageSIze=2);
    public record GetProductsResponse(IEnumerable<Product> products);

    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           app.MapGet("/products" ,async (GetProductsRequest request , ISender sender) =>
           {
               
           })
        }
    }
}
