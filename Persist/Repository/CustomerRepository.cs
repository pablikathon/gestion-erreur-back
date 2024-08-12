using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public  IQueryable<CustomerEntity> GetAllAsync()
        {
            return  _context.Customer.AsQueryable();
        }

        public async Task<CustomerEntity?> GetByIdAsync(string id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<CustomerEntity> AddAsync(CustomerEntity customerEntity)
        {
            _context.Customer.Add(customerEntity);
            await _context.SaveChangesAsync();
            return customerEntity;
        }

        public async Task<bool> UpdateAsync(CustomerEntity customerEntity)
        {
            var c = _context.Customer.Find(customerEntity.Id);
            if (c != null)
            {   
                c = customerEntity;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Boolean> DeleteAsync(string id)
        {
            CustomerEntity? customerEntity = await _context.Customer.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Customer.Remove(customerEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}