using Microsoft.EntityFrameworkCore;
using SimpleInvoiceManager.DAO.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.DAO.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyAllEntityConfigurations(this ModelBuilder builder)
        {
            //TODO: Apply all entity configurations in assembly
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new InvoiceConfiguration());
            builder.ApplyConfiguration(new InvoiceItemConfiguration());

            return builder;
        }
    }
}
