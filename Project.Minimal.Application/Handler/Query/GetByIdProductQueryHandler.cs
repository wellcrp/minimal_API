using AutoMapper;
using MediatR;
using Project.Minimal.Application.Query;
using Project.Minimal.Domain.Product;
using Project.Minimal.Domain.Response;
using Project.Minimal.Infrastructure.Interface;

namespace Project.Minimal.Application.Handler.Query
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryCommand, ProductResponse>
    {
        private readonly IProductRepository<ProductModel> _product;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository<ProductModel> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(GetByIdProductQueryCommand request, CancellationToken cancellationToken)
        {
            var result = _product.GetProductById(request.ProductId).Result;
            var mapper = _mapper.Map<ProductResponse>(result);
            
            return Task.FromResult(mapper);
        }
    }
}
