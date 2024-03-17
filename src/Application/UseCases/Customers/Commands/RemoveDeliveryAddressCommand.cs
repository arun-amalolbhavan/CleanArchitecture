using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers.Commands
{
    public record RemoveDeliveryAddressCommand(int deliveryAddressId) : IRequest<int>;

    public class RemoveDeliveryAddressCommandHandler : IRequestHandler<RemoveDeliveryAddressCommand, int>
    {
        public Task<int> Handle(RemoveDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
