﻿using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region [Table]
            builder.ToTable("User");
            #endregion

            #region [Primary Key]
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            #endregion

            #region [Properties]
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(120);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Image)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(256)
                .HasDefaultValue(null);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .HasDefaultValue(null);

            builder.Property(x => x.Bio)
                .HasColumnName("Bio")
                .HasColumnType("text")
                .HasDefaultValue(null);
            #endregion

            #region [Index]
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
            #endregion
        }
    }
}
