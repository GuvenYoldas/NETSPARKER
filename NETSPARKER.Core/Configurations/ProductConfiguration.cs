using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETSPARKER.Common.Helpers;
using NETSPARKER.Core.Entities;
using System;

namespace NETSPARKER.Core.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(q => q.ID);

            builder.Property(q => q.Name).IsRequired().HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.Url).IsRequired().HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.Interval).IsRequired().HasColumnType(typeof(int).ConvertToDbType());
            builder.Property(q => q.LastMonitorTime).IsRequired(false).HasColumnType(typeof(DateTime).ConvertToDbType());
            builder.Property(q => q.NextMonitorTime).IsRequired().HasColumnType(typeof(DateTime).ConvertToDbType());
           // builder.HasOne(q => q.NOtif).WithMany(q => q.Product).HasForeignKey(q => q.IDNoti);
        }
    }
}
