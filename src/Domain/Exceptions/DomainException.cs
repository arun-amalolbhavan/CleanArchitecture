using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Constants;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message): base(message) { }

        public static void ThrowIfNullOrWhiteSpace(string field, string fieldName)
        {
            if(string.IsNullOrWhiteSpace(field))
                throw new DomainException(string.Format(Customer.DOMAIN_EXECPTION_MSG_TEMPLATE, fieldName));
        }

        public static void ThrowIfEmpty(Guid id, string fieldName)
        {
            if (Guid.Empty == id)
                throw new DomainException(string.Format(Customer.DOMAIN_EXECPTION_MSG_TEMPLATE, fieldName));
        }

        public static void ThrowIfNull(Customers.Customer? result, string message)
        {
            if (result == null)
                throw new DomainException(message);
        }
    }
}
