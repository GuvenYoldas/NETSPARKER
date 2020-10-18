using Microsoft.EntityFrameworkCore;
using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Repositories.Base;
using NETSPARKER.Infrastructure.Interfaces;

namespace NETSPARKER.Infrastructure.Repositories
{
    public class ProductNotificationRepository: GenericRepository<ProductNotificationEntity, int>, IProductNotification
    {
        public ProductNotificationRepository(DbContext context) : base(context)
        {
        }
    }
}
