using Application.Interfaces.Repositories;
using Domain.Customers;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Guid> SaveNewCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await SaveChangesAsync();
            return customer.Id;
        }

        public async Task<Customer> GetCustomerAsync(Guid customerId)
        {
            var query = from customer in _dbContext.Customers
                           where customer.Id == customerId
                           select customer;
            var result = await query.Include(x => x.DeliveryAddresses).FirstOrDefaultAsync();

            DomainException.ThrowIfNull(result, $"Customer Id ({customerId}) does not exist");

            return result;
        }
    }
}
