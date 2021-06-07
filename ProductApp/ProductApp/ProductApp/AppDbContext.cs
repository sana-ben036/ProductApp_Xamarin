using Microsoft.EntityFrameworkCore;
using ProductApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        private readonly string _dbPath;

      public AppDbContext(string dbPath)
        {
            _dbPath = dbPath;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) 
        {
            optionBuilder.UseSqlite($"Data Source= {_dbPath}");



        }




    }
}
