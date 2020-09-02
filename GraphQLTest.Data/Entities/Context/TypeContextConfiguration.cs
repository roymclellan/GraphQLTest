using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTest.Data.Entities.Context
{
    public class TypeContextConfiguration : IEntityTypeConfiguration<Type>
    {
        private int[] _ids;

        public TypeContextConfiguration(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Type> builder)
        {

        }
    }
}
