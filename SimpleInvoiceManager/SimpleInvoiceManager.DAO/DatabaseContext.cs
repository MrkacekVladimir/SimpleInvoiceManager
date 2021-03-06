﻿using Microsoft.EntityFrameworkCore;
using SimpleInvoiceManager.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleInvoiceManager.DAO.Extensions;

namespace SimpleInvoiceManager.DAO
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DatabaseContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllEntityConfigurations();                                    
        }

        #region DbSets

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        #endregion
    }
}
