using ProductGrpcService;
using GraphQLApiGateway.Queries;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGrpcClient<ProductService.ProductServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7071"); 
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<ProductQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();