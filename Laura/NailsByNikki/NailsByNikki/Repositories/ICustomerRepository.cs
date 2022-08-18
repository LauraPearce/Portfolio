using NailsByNikki.Models;

namespace NailsByNikki.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        Customer Create(Customer customer);

        void Update(Customer customer);

        void Delete(Customer customer);
    }
}
