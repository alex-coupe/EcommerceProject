using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BaseCategory { get; set; }

        [Required]
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}