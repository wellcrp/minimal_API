using Project.Minimal.Domain.Product;

namespace Project.Minimal.Infrastructure.Interface
{
    public interface IProductRepository<Tentity> where Tentity : class
    {
        Task<List<ProductModel>> GetProductAll();
        Task<ProductModel> GetProductById(Guid productId);
    }
}