using Microsoft.EntityFrameworkCore;
using NETSPARKER.Core.Entities;
using NETSPARKER.Infrastructure.Repositories.Base;
using NETSPARKER.Infrastructure.Interfaces;


namespace NETSPARKER.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserEntity, int>, IUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}
