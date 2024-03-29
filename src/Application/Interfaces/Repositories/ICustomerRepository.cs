﻿using Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository: IRepository
    {
        Task<Guid> SaveNewCustomer(Customer customer);

        Task<Customer> GetCustomerAsync(Guid customerId);
    }
}
