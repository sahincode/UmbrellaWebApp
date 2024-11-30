
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id):ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async  Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handler is called by {@command}", command);
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if(product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }
             session.Delete<Product>(product.Id);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductResult(true);
            
        }
    }
}
