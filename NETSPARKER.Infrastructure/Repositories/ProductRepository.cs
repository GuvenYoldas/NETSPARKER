using Microsoft.EntityFrameworkCore;
using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Repositories.Base;
using NETSPARKER.Infrastructure.Interfaces;

namespace NETSPARKER.Infrastructure.Repositories
{
    public class ProductRepository: GenericRepository<ProductEntity, int>, IProduct
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
