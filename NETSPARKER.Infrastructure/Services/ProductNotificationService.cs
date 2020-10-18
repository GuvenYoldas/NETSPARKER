using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.Infrastructure.Interfaces.Base;
using NETSPARKER.Infrastructure.Services.Base;
using System;

namespace NETSPARKER.Infrastructure.Services
{
    public class ProductNotificationService : EntityService<ProductNotificationEntity, int>, IProductNotification
    {
        IUnitOfWork _unitOfWork;
        IProductNotification _productNotificationRepository;

        public ProductNotificationService(IUnitOfWork unitOfWork, IProductNotification productNotificationRepository) : base(unitOfWork, productNotificationRepository)
        {
            _unitOfWork = unitOfWork;
            _productNotificationRepository = productNotificationRepository;
        }
    }
}
