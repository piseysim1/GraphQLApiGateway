using CategoryGrpcService;
using GraphQLApiGateway.Extension;
using GraphQLApiGateway.Queries;
using ProductGrpcService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<ProductService.ProductServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7071");

});
builder.Services.AddGrpcClient<CategoryService.CategoryServiceClient>(
    options =>
    {
        options.Address = new Uri("https://localhost:7071");
    });


builder.Services.AddCustomGraphQL();

var app = builder.Build();
app.MapGraphQL();
app.Run();