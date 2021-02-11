using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.DataModels.Components
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }

        public string ReviewBody { get; set; }

        public int Rating { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
