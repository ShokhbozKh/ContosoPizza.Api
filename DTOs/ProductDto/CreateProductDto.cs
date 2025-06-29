namespace ContosoPizza.Api.DTOs.ProductDto
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set;  }
        // Additional properties can be added here as needed
    }
}
