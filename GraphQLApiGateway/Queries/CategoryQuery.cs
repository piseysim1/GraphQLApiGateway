using CategoryGrpcService;
using GraphQLApiGateway.Types;
using CategoryListResponse = GraphQLApiGateway.Types.CategoryListResponse;

namespace GraphQLApiGateway.Queries
{
    public class CategoryQuery
    {
        public async Task<CategoryListResponse> GetProductDetailsById(int id,
           [Service] CategoryService.CategoryServiceClient grpcClient)
        {
          
            var grpcRequest = new CategoryByIdRequest { Id = id };
            var response = await grpcClient.GetCategoryByIdAsync(grpcRequest);

           
            return new CategoryListResponse
            {
                Id = response.Id,
                Name = response.Name,
                Note = response.Note

            };
         }
        
        public async Task<IEnumerable<CategoryType>> GetAllProduct([Service] CategoryService.CategoryServiceClient grpcClient)
        {
            var response = await grpcClient.GetAllCategoryAsync(
                new EmptyRequest());
            return response.Categories.Select(c => new CategoryType
            {
                Id = c.Id,
                Name = c.Name,
                Note = c.Note
            });
        }

    }
}
