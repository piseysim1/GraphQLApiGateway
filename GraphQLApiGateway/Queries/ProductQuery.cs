using GraphQLApiGateway.Types;
using ProductGrpcService;

namespace GraphQLApiGateway.Queries
{
    public class ProductQuery
    {
        public async Task<IEnumerable<ProductType>> GetProducts( [Service] ProductService.ProductServiceClient grpcClient)
        {
            var response = await grpcClient.GetAllProductsAsync(new EmptyRequest());
            return response.Products.Select(p => new ProductType
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                //Category = p.Category
            });
        }

        public async Task<ProductType?> GetProductById( int id, [Service] ProductService.ProductServiceClient grpcClient)
        {
            try
            {
                var response = await grpcClient.GetProductByIdAsync(new ProductByIdRequest { Id = id });
                return new ProductType
                {
                    Id = response.Id,
                    Name = response.Name,
                    Price = response.Price,
                    //Category = response.Category
                };
            }
            catch (Grpc.Core.RpcException)
            {
                return null;
            }
        }
    }
}
