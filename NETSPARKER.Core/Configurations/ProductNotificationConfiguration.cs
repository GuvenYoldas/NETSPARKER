using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETSPARKER.Common.Helpers;
using NETSPARKER.Core.Entities;
using System;

namespace NETSPARKER.Core.Configurations
{
    public class ProductNotificationConfiguration : IEntityTypeConfiguration<ProductNotificationEntity>
    {
        public void Configure(EntityTypeBuilder<ProductNotificationEntity> builder)
        {
            builder.ToTable("ProductNotifications");
            builder.HasKey(q => q.ID);

            builder.Property(q => q.IDProduct).IsRequired().HasColumnType(typeof(int).ConvertToDbType());
            builder.Property(q => q.IDNotificationType).IsRequired().HasColumnType(typeof(int).ConvertToDbType());
            builder.Property(q => q.IDMonitoringInterval).IsRequired().HasColumnType(typeof(int).ConvertToDbType());
           
            builder.HasOne(q => q.Products).WithMany(q => q.ProductNotification).HasForeignKey(q => q.IDProduct);
        }

    }
}
