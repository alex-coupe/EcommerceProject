using System.ComponentModel.DataAnnotations;

namespace ProductService.Models
{
    public class Image
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        [MinLength(10)]
        public string AltText { get; set; }
    }
}