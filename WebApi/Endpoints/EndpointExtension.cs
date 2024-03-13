using System.Runtime.CompilerServices;
using WebApi.Endpoints.Handlers;

namespace WebApi.Endpoints
{
    public static class EndpointExtension
    {
        public static void MapEndpoints(this WebApplication app)
        {
            var api = app.MapGroup("/api")
                .AllowAnonymous();

            api.MapCustomerEndpoints();
        }

        private static void MapCustomerEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("/customer", Customer.CreateCustomer)
                .WithName("CreateCustomer")
                .WithOpenApi();
        }
    }
}
