using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Author { get; set; }

        public string Body { get; set; }

        public int Count { get; set; }

        public int Votes { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
