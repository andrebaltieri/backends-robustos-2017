using System;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Data.Contexts;

namespace Store.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;

        public CustomerRepository(StoreDataContext context)
        {
            _context = context;
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}