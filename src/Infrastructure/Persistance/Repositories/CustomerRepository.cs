using Application.Interfaces.Repositories;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public AppDbContext DbContext { get; set; }
        public CustomerRepository(AppDbContext context)
        {
            DbContext = context;
        }
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            DbContext.Customers.Add(customer);
            await DbContext.SaveChangesAsync();
            return customer.Id;
        }
    }
}
