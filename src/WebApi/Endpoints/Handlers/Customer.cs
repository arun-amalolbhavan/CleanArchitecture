using Application.UseCases.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Endpoints.Handlers
{
    public static class Customer
    {
        public static async Task<IResult> CreateCustomer(CreateCustomerCommand command, IMediator mediator)
        {
            var customerId = await mediator.Send(command);
            return Results.Ok(customerId);
        }
    }
}
