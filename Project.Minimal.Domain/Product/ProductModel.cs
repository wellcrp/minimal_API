namespace Project.Minimal.Domain.Product
{
    public class ProductModel
    {
        public ProductModel(Guid productId, int productSKU, string productDescription)
        {
            ProductId = productId;
            ProductSKU = productSKU;
            ProductDescription = productDescription;
        }

        public Guid ProductId { get; set; }
        public int ProductSKU { get; set; }
        public string ProductDescription { get; set; } = default!;
    }
}
