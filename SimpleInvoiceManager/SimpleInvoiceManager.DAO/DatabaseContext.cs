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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Invoice>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<InvoiceItem>().Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
        }

        #region DbSets

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        #endregion
    }
}
