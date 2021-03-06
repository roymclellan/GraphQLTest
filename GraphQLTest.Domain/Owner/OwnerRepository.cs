﻿using GraphQLTest.Data.Entities.Context;
using System.Collections.Generic;
using System.Linq;
using Entities = GraphQLTest.Data.Entities;

namespace GraphQLTest.Domain.Owner
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Entities.Owner> GetAll() => _context.Owner.ToList();

        public Entities.Owner GetById(int Id) => _context.Owner.SingleOrDefault(x => x.Id.Equals(Id));

        public Entities.Owner CreateOwner(Entities.Owner owner)
        {
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public Entities.Owner UpdateOwner(Entities.Owner dbOwner, Entities.Owner owner)
        {
            _context.Attach(dbOwner);
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;

            _context.SaveChanges();

            return dbOwner;
        }

        public void DeleteOwner(Entities.Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }
    }
}
