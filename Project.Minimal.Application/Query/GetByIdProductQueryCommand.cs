using MediatR;
using Project.Minimal.Domain.Response;

namespace Project.Minimal.Application.Query
{
    public class GetByIdProductQueryCommand : IRequest<ProductResponse>
    {
        public GetByIdProductQueryCommand(Guid productId)
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
        public int ProductSKU { get; set; }
        public string ProductDescription { get; set; } = default!;
    }
}
