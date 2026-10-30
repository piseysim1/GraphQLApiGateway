using CategoryGrpcService;
using GraphQLApiGateway.Types;

namespace GraphQLApiGateway.Queries
{
    [ExtendObjectType(typeof(ProductQuery))]
    public class CategoryQuery
    {
        
        public async Task<CategoryType> GetCategoryDetailsById(
            int id,
            [Service] CategoryService.CategoryServiceClient grpcClient)
        {
            var grpcRequest = new CategoryByIdRequest
            {
                Id = id
            };

            var response = await grpcClient.GetCategoryByIdAsync(
                grpcRequest
            );

            return new CategoryType
            {
                Id = response.Id,
                Name = response.Name,
                Note = response.Note
            };
        }

        // Get all categories
        public async Task<IEnumerable<CategoryType>> GetAllCategories(
            [Service] CategoryService.CategoryServiceClient grpcClient)
        {
            var response = await grpcClient.GetAllCategoriesAsync(
                new EmptyRequest()
            );

            return response.Categories.Select(c => new CategoryType
            {
                Id = c.Id,
                Name = c.Name,
                Note = c.Note
            });
        }
    }
}