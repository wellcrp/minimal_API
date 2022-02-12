using AutoMapper;
using MediatR;
using Project.Minimal.Application.Query;
using Project.Minimal.Domain.Product;
using Project.Minimal.Domain.Response;
using Project.Minimal.Infrastructure.Interface;

namespace Project.Minimal.Application.Handler.Query
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryCommand, IList<ProductResponse>>
    {
        private readonly IProductRepository<ProductModel> _product;
        private readonly IMapper _mapper;
        public GetAllProductQueryHandler(IProductRepository<ProductModel> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public Task<IList<ProductResponse>> Handle(GetAllProductQueryCommand request, CancellationToken cancellationToken)
        {            
            var result = _product.GetProductAll().Result;
            var mapper = _mapper.Map<IList<ProductResponse>>(result);

            return Task.FromResult(mapper);
        }
    }
}
