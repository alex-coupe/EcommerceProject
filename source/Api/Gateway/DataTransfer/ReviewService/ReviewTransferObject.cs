using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataTransfer.ReviewService
{
    public class ReviewTransferObject
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Author { get; set; }

        public string Body { get; set; }

        public int Count { get; set; }

        public int Votes { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
