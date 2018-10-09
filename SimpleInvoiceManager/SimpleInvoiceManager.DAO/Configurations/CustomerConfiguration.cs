using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.DAO.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.StreetAddress)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(p => p.City)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.State)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.ZipCode)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();            
        }
    }
}
