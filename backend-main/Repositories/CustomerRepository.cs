using App.Data.Entities;
using App.Infrastructure.Core;

namespace App.Main.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(GlobalContext dbContext) : base(dbContext)
        { }
    }
}
