using AutoMapper;
using MediatR;
using Project.Minimal.Application.Query;
using Project.Minimal.Domain.Product;
using Project.Minimal.Domain.Response;
using Project.Minimal.Infrastructure.Interface;

namespace Project.Minimal.Application.Handler.Query
{
    public class GetBySkuProductQueryHandler : IRequestHandler<GetBySkuProductQueryCommand, ProductResponse>
    {
        private readonly IProductRepository<ProductModel> _product;
        private readonly IMapper _mapper;

        public GetBySkuProductQueryHandler(IProductRepository<ProductModel> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public Task<ProductResponse> Handle(GetBySkuProductQueryCommand request, CancellationToken cancellationToken)
        {
            var result = _product.GetProductBySku(request.ProductSKU).Result;
            var mapper = _mapper.Map<ProductResponse>(result);
            
            return Task.FromResult(mapper);
        }
    }
}
