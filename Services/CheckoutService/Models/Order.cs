using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckoutService.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstLine { get; set; }
       
        public string SecondLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string PostalCode { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal DeliveryCost { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal DeliveryTax { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Total { get; set; }
        [Required]
        public string CardType { get; set; }
        [Required]
        public string CardLastFourDigits { get; set; }

    }
}
