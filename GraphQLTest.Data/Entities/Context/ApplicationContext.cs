using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GraphQLTest.Data.Entities.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var ids = new int[] { new int(), new int() };

            modelBuilder.ApplyConfiguration(new OwnerContextConfiguration(ids));
            modelBuilder.ApplyConfiguration(new AccountContextConfiguration(ids));
            modelBuilder.ApplyConfiguration(new TypeContextConfiguration(ids));
        }

        public DbSet<Owner> Owner { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Type> Type { get; set; }
    }
}
