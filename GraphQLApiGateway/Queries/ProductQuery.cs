using GraphQLApiGateway.Types;
using ProductGrpcService;
using ProductListResponse = GraphQLApiGateway.Types.ProductListResponse;

namespace GraphQLApiGateway.Queries
{
    public class ProductQuery
    {
        public async Task<ProductListResponse> GetProductDetailsById( int productId,
            [Service] ProductService.ProductServiceClient grpcClient)
        {
            // 1. Call the gRPC server using your request message
            var grpcRequest = new ProductByIdRequest { Id = productId };
            var response = await grpcClient.GetProductByIdAsync(grpcRequest);

            // 2. Map gRPC response to your GraphQL Types
            return new ProductListResponse
            {
                Product = new ProductType
                {
                    Id = response.Products.Id,
                    Name = response.Products.Name,
                    Description = response.Products.Description,
                    Price = response.Products.Price,
                    CategoryId= response.Products.CategoryId,
                },
                Category = new CategoryType
                {
                    Id = response.Category.Id,
                    Name = response.Category.Name,
                    Note = response.Category.Note
                },
                Inventory = new InventoryType
                {
                    Id = response.Inventory.Id,
                    ProductId = response.Inventory.ProductId,
                    StockQuantity = response.Inventory.StockQuantity,
                }
                
            };
            
        }
        public async Task<IEnumerable<ProductType>>GetAllProduct([Service] ProductService.ProductServiceClient grpcClient)
        {
            var response = await grpcClient.GetAllProductsAsync(new EmptyRequest());
            return response.Product.Select(p => new ProductType 
            { 
                Id = p.Id,
                Name= p.Name,
                Description= p.Description,
                Price = p.Price,
                CategoryId= p.CategoryId
            });
        }
        
    }
    
}
