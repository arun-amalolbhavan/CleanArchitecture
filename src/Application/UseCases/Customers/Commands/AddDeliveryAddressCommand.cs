using Application.Interfaces.Repositories;
using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers.Commands
{
    public record AddDeliveryAddressCommand(Guid CustomerId, string Fullname,
            string PhoneNumber,
            string Building,
            string Street,
            string Landmark,
            string Pincode,
            string City,
            string State,
            string DeliveryInstruction) : IRequest<Guid>;

    public class AddDeliveryAddressCommandHandler : IRequestHandler<AddDeliveryAddressCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        public AddDeliveryAddressCommandHandler(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }
        public async Task<Guid> Handle(AddDeliveryAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerAsync(request.CustomerId);
            var address = customer.AddDeliveryAddress(request.Fullname,
                request.PhoneNumber,
                request.Building,   
                request.Street,
                request.Landmark,
                request.Pincode,
                request.City,
                request.State,
                request.DeliveryInstruction);

            await _customerRepository.SaveChangesAsync();
            return address.Id;
        }
    }
}
