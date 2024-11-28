
namespace Catalog.API.Products.GetProductByName
{
    public record GetProductByNameRequest(string Name);
    public record GetProductByNameResponse(Product Product);
    public class GetProductByNameEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/{name}", async (string name, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByNameQuery(name));
                var response = result.Adapt<GetProductByNameResponse>();
                return Results.Ok(response);
            }).WithName("GetProductByName")
            .Produces<GetProductByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Name")
            .WithDescription("Get Product By Name");
        }
    }
}