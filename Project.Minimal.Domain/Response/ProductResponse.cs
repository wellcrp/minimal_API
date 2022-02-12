namespace Project.Minimal.Domain.Response
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }
        public int ProductSKU { get; set; }
        public string ProductDescription { get; set; } = default!;
    }
}
