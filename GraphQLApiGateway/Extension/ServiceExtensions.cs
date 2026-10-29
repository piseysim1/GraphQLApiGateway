using Microsoft.Extensions.DependencyInjection;
using GraphQLApiGateway.Queries;

namespace GraphQLApiGateway.Extension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<ProductQuery>();
            return services;
        }
    }
}