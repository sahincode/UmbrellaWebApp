
using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductById
{
     public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/GetById", async ([AsParameters] GetProductByIdRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(request.Id));
                var respone = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(respone);
            }).WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
