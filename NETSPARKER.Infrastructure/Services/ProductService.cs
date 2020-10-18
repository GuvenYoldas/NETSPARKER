using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.Infrastructure.Interfaces.Base;
using NETSPARKER.Infrastructure.Services.Base;
using System;

namespace NETSPARKER.Infrastructure.Services
{

    public class ProductService : EntityService<ProductEntity, int>, IProduct
    {
        IUnitOfWork _unitOfWork;
        IProduct _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProduct productRepository) : base(unitOfWork, productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
    }
}
