using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;

namespace Repositories
{
    public class CustomerHaveLicenceToApplicationRepository : ICustomerHaveLicenceToApplicationRepository
    {
        private readonly AppDbContext _context;

        public CustomerHaveLicenceToApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerHaveLicenceToApplicationEntity> AddAsync(
            CustomerHaveLicenceToApplicationEntity CustomerHaveLicenceToApplication)
        {
            try
            {
                _context.CustomerHaveLicenceToApplications.Add(CustomerHaveLicenceToApplication);
                await _context.SaveChangesAsync();
                await _context.LoadReferencesAsync(CustomerHaveLicenceToApplication, e => e.Application,
                    e => e.Customer);
                return CustomerHaveLicenceToApplication;
            }
            catch (System.Exception e)
            {
                throw e.InnerException;
            }
        }

        public async Task<bool> DeleteAsync(string idClient, string idApplication)
        {
            CustomerHaveLicenceToApplicationEntity? customerHaveLicenceToApplications =
                await _context.CustomerHaveLicenceToApplications.FindAsync(idClient, idApplication);
            if (customerHaveLicenceToApplications != null)
            {
                _context.CustomerHaveLicenceToApplications.Remove(customerHaveLicenceToApplications);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public IQueryable<CustomerHaveLicenceToApplicationEntity> GetAllAsync()
        {
            return _context.CustomerHaveLicenceToApplications
                .Include(c => c.Customer)
                .Include(c => c.Application)
                .AsQueryable();
        }

        public async Task<CustomerHaveLicenceToApplicationEntity?> GetByIdAsync(string idCustommer,
            string idApplication)
        {
            return await _context.CustomerHaveLicenceToApplications.SingleAsync(c =>
                c.CustomerId == idCustommer && c.ApplicationId == idApplication);
        }

        public async Task<bool> UpdateAsync(CustomerHaveLicenceToApplicationEntity CustomerHaveLicenceToApplication)
        {
            var clt = await _context.CustomerHaveLicenceToApplications.FindAsync(
                CustomerHaveLicenceToApplication.ApplicationId, CustomerHaveLicenceToApplication.CustomerId);
            if (clt != null)
            {
                clt.Cost = CustomerHaveLicenceToApplication.Cost;
                clt.UpdatedAt = CustomerHaveLicenceToApplication.UpdatedAt;
                clt.IsActive = CustomerHaveLicenceToApplication.IsActive;
                clt.BeginingSupport = CustomerHaveLicenceToApplication.BeginingSupport;
                clt.EndingSupport = CustomerHaveLicenceToApplication.EndingSupport;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}