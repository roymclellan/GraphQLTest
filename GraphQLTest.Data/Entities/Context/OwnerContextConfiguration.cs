using GraphQLTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQLTest.Data.Entities.Context
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {
        private int[] _ids;

        public OwnerContextConfiguration(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            //builder
            //  .HasData(
            //    new Owner
            //    {
            //        Id = _ids[0],
            //        Name = "John Doe",
            //        Address = "John Doe's address"
            //    },
            //    new Owner
            //    {
            //        Id = _ids[1],
            //        Name = "Jane Doe",
            //        Address = "Jane Doe's address"
            //    }
            //);
        }
    }
}
