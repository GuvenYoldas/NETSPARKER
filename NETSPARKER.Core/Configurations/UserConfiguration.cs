using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETSPARKER.Common.Helpers;
using NETSPARKER.Core.Entities;
using System;

namespace NETSPARKER.Core.Configurations
{

    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("UserAccounts");
            builder.HasKey(q => q.ID);

            builder.Property(q => q.Name).IsRequired(false).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.LastName).IsRequired(false).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.UserName).IsRequired(false).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.Email).IsRequired().HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.PasswordHash).IsRequired().HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.SaltString).IsRequired().HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.AvatarUrl).IsRequired(false).HasColumnType(typeof(string).ConvertToDbType());
            builder.Property(q => q.UserType).IsRequired().HasColumnType(typeof(int).ConvertToDbType());

        }
    }
}

