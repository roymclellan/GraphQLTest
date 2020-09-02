using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQLTest.Data.Entities.Context
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        private int[] _ids;

        public AccountContextConfiguration(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
           // builder
           //     .HasData(
           //     new Account
           //     {
           //         Id = Guid.NewGuid(),
           //         Type = TypeOfAccount.Cash,
           //         Description = "Cash account for our users",
           //         OwnerId = _ids[0]
           //     },
           //     new Account
           //     {
           //         Id = Guid.NewGuid(),
           //         Type = TypeOfAccount.Savings,
           //         Description = "Savings account for our users",
           //         OwnerId = _ids[1]
           //     },
           //     new Account
           //     {
           //         Id = Guid.NewGuid(),
           //         Type = TypeOfAccount.Income,
           //         Description = "Income account for our users",
           //         OwnerId = _ids[1]
           //     }
           //);
        }
    }
}
