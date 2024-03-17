using Domain.Constants;
using Domain.Core;
using Domain.Customers.Entities;
using Domain.Exceptions;

namespace Domain.Customers
{
    public class Customer : AggregateRoot
    {
        private Guid _id;
        public Guid Id => _id;

        public string Name { get; private set; } = string.Empty;
        public string EmailAddress { get; private set; }

        private List<DeliveryAddress> _deliveryAddresses;
        public IEnumerable<DeliveryAddress> DeliveryAddresses => _deliveryAddresses.ToList();

        public Customer(string name, string emailAddress)
        {
            DomainException.ThrowIfNullOrWhiteSpace(name, "Customer.Name");
            DomainException.ThrowIfNullOrWhiteSpace(emailAddress, "Customer.EmailAddress");
            Name = name;
            EmailAddress = emailAddress;
            _deliveryAddresses = new List<DeliveryAddress>();
        }

        public DeliveryAddress AddDeliveryAddress(string fullname,
            string phoneNumber,
            string building,
            string street,
            string landmark,
            string pincode,
            string city,
            string state,
            string deliveryInstruction)
        {
            if (_deliveryAddresses.Count >= Constants.Customer.MAX_DELIVERY_ADDRESS_COUNT)
                throw new DomainException(string.Format(Constants.Customer.DELIVERY_ADDRESS_LIMIT_EXCEPTION_MSG_TEMPLATE, Constants.Customer.MAX_DELIVERY_ADDRESS_COUNT));

            var address = DeliveryAddress.Create(this.Id, fullname,
                phoneNumber,
                building,
                street,
                landmark,
                pincode,
                city,
                state,
                deliveryInstruction);
            _deliveryAddresses.Add(address);
            return address;
        }

    }
}
