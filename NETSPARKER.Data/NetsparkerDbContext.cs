using Microsoft.EntityFrameworkCore;
using NETSPARKER.Core.Configurations;
using NETSPARKER.Core.Entities;
using System.Linq;

namespace NETSPARKER.Data
{    /// The NETSPARKERDbContext
     /// </summary>
     /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class NetsparkerDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetsparkerDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public NetsparkerDbContext(DbContextOptions<NetsparkerDbContext> options) : base(options)
        {

        }

        #region |       DbSet Entity Classes         |

        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<ProductNotificationEntity> ProductNotification { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region |       ModelBuilder Configurations         |


            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductNotificationConfiguration());
            #endregion

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
