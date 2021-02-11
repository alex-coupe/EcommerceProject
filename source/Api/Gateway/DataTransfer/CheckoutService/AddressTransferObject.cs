using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.CheckoutService
{
    public class AddressTransferObject
    {
        public string FirstLine { get; set; }

        public string SecondLine { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }
    }
}
