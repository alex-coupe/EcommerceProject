using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class PaymentInfo
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }

        public string Csv { get; set; }

        public string CardHolder { get; set; }
        
    }
}
