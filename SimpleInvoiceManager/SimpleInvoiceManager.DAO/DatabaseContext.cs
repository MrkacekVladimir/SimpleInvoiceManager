using Microsoft.EntityFrameworkCore;
using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleInvoiceManager.DAO
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        #region DbSets

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }

        #endregion
    }
}
