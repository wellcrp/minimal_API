using MediatR;
using Project.Minimal.Domain.Response;

namespace Project.Minimal.Application.Query
{
    public class GetBySkuProductQueryCommand : IRequest<ProductResponse>
    {
        public GetBySkuProductQueryCommand(int productSKU)
        {
            ProductSKU = productSKU;
        }

        public Guid ProductId { get; set; }
        public int ProductSKU { get; set; }
        public string ProductDescription { get; set; } = default!;
    }
}
