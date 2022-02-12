using MediatR;
using Project.Minimal.Domain.Response;

namespace Project.Minimal.Application.Query
{
    public class GetAllProductQueryCommand : IRequest<IList<ProductResponse>>
    {
        public Guid ProductId { get; set; }
        public int ProductSKU { get; set; }
        public string ProductDescription { get; set; } = default!;
    }
}
