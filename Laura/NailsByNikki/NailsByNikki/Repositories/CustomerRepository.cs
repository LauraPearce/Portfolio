using Microsoft.EntityFrameworkCore;
using NailsByNikki.Data;
using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NailsByNikkiDbContext _context;

        public CustomerRepository(NailsByNikkiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking().ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.AsNoTracking().SingleOrDefault(c => c.CustomerId == id);
        }

        public Customer Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public void Update(Customer customerToUpdate)
        {
            _context.Customers.Update(customerToUpdate);
            _context.SaveChanges();
        }

        public void Delete(Customer customerToDelete)
        {
            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();
        }
    }
}
