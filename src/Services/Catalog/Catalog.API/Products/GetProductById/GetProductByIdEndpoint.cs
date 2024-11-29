
namespace Catalog.API.Products.GetProductById
{
     public record GetProductByIdRequest(Guid Id);
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("product/{Id}", async (Guid Id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(Id));
                var respone = result.Adapt<GetProductByIdRequest>();
                return Results.Ok(respone);
            }).WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
