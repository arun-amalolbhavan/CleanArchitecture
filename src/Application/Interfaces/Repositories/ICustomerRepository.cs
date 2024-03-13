using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<int> AddCustomerAsync(Customer customer);
    }
}
