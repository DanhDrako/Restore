using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(100, double.PositiveInfinity, ErrorMessage = "Price must be a positive value.")]
        public long Price { get; set; }

        public IFormFile? File { get; set; }

        [Required]
        public required string Type { get; set; }

        [Required]
        public required string Brand { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity in stock must be a non-negative integer.")]
        public int QuantityInStock { get; set; }
    }
}
