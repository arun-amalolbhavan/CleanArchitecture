using Domain.Customers;
using Domain.Customers.Entities;
using Domain.Exceptions;

namespace Tests.Domain
{
    public class CustomerTests
    {
        [Fact]
        public void ShouldNotAddCustomerWithoutName()
        {
            var exception = Assert.Throws<DomainException>(() => new Customer(string.Empty, "john@email.com"));
            Assert.Equal("Customer.Name cannot be empty.", exception.Message);
        }

        [Fact]
        public void CanAddCustomerAddress()
        {
            var customer = new Customer("John", "john@email.com");
           
            customer.AddDeliveryAddress("John Doe",
                "123456789",
                "building 1",
                "street 1",
                "",
                "12345",
                "city",
                "state",
                "");
            var customerDeliveryAddress = customer.DeliveryAddresses.FirstOrDefault();
            
            Assert.NotNull(customerDeliveryAddress);
            Assert.Equal("John Doe",customerDeliveryAddress.FullName);

        }

        [Fact]
        public void CanAddSameDeliveryAddressMoreThanOnceForCustomer()
        {
            var customer = new Customer("John", "john@email.com");

            customer.AddDeliveryAddress("John Doe",
                "123456789",
                "building 1",
                "street 1",
                "",
                "12345",
                "city",
                "state",
                "");

            customer.AddDeliveryAddress("John Doe",
                "123456789",
                "building 1",
                "street 1",
                "",
                "12345",
                "city",
                "state",
                "");

            var address1 = customer.DeliveryAddresses.First();
            var address2 = customer.DeliveryAddresses.Last();

            Assert.NotEqual(address1.Id, address2.Id);
        }

        [Fact]
        public void CannotAddMoreThanTenCustomerDeliveryAddress()
        {
            var customer = new Customer("John", "john@email.com");
            
            for(var i = 0; i< 10; i++)
                customer.AddDeliveryAddress("John Doe",
                "123456789",
                "building 1",
                "street 1",
                "",
                "12345",
                "city",
                "state",
                "");

            var exception = Assert.Throws<DomainException>(() => customer.AddDeliveryAddress("John Doe",
                "123456789",
                "building 1",
                "street 1",
                "",
                "12345",
                "city",
                "state",
                ""));

            Assert.Equal("Total delivery addresses exceeded the limit of 10", exception.Message);

        }

    }
}