using Domain.Core;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Customers.Entities
{
    public class DeliveryAddress : Entity
    {
        private Guid _id;
        public Guid Id => _id;
        public string FullName { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public string Building { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string Landmark { get; private set; } = string.Empty;
        public string Pincode { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string DeliveryInstruction { get; private set; } = string.Empty;

        private DeliveryAddress() { }
        private DeliveryAddress(string fullname,
            string phoneNumber,
            string building,
            string street,
            string landmark,
            string pincode,
            string city,
            string state,
            string deliveryInstruction)
        {
            DomainException.ThrowIfNullOrWhiteSpace(fullname, "Address.FullName");
            DomainException.ThrowIfNullOrWhiteSpace(building, "Address.Building");
            DomainException.ThrowIfNullOrWhiteSpace(street, "Address.Street");
            DomainException.ThrowIfNullOrWhiteSpace(pincode, "Address.Pincode");
            DomainException.ThrowIfNullOrWhiteSpace(city, "Address.City");
            DomainException.ThrowIfNullOrWhiteSpace(state, "Address.State");

            _id = Guid.NewGuid();
            FullName = fullname;
            PhoneNumber = phoneNumber;
            Building = building;
            Street = street;
            Landmark = landmark;
            Pincode = pincode;
            City = city;
            State = state;
            DeliveryInstruction = deliveryInstruction;
        }

        public static DeliveryAddress Create(string fullname,
            string phoneNumber,
            string building,
            string street,
            string landmark,
            string pincode,
            string city,
            string state,
            string deliveryInstruction)
        {
            return new DeliveryAddress(fullname, phoneNumber, building, street, landmark, pincode, city, state, deliveryInstruction);
        }
    }
}
