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
        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
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

        public async Task<CustomerEntity?> UpdateAsync(CustomerEntity customerEntity)
        {
            _context.Entry(customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Customer.FindAsync(customerEntity.Id);
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