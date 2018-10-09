using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.DAO.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {            
            builder.Property(p => p.Tax)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(p => p.InvoiceDate)
                .IsRequired();

            builder.Property(p => p.PaymentDueDate)
                .IsRequired();

            builder.Property(p => p.Tax)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
        }
    }
}
