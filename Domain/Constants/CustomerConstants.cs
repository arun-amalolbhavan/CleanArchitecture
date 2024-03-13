using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public class Customer
    {
        public const string DOMAIN_EXECPTION_MSG_TEMPLATE = "{0} cannot be empty.";
        public const string DELIVERY_ADDRESS_LIMIT_EXCEPTION_MSG_TEMPLATE = "Total delivery addresses exceeded the limit of {0}";

        public const int MAX_DELIVERY_ADDRESS_COUNT = 10;
    }
}
