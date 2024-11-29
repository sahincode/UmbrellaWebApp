


using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductByName
{
    public record  GetProductByNameQuery(string Name):IQuery<GetProductByNameResult>;
    public record GetProductByNameResult(Product Product);

    public class GetProductByNameQueryHandler(IDocumentSession session, ILogger<GetProductByNameQueryHandler> logger) : IQueryHandler<GetProductByNameQuery, GetProductByNameResult>
    {
        public async  Task<GetProductByNameResult> Handle(GetProductByNameQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByNameHandler.Handler is called by {@query}", query);
            var product= await  session.Query<Product>().Where(p=>p.Name ==query.Name).FirstOrDefaultAsync();
            if (product is  null)
            {
                throw new ProductNotFoundException(query.Name);
            }
            return new GetProductByNameResult(product);
           
        }
    }
}
