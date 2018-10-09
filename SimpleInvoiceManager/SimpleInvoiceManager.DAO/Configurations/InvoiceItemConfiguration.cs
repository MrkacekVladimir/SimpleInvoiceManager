using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.DAO.Configurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(p => p.PricePerUnit)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(p => p.Total)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
        }
    }
}
