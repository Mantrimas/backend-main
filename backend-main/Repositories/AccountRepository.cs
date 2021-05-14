using App.Data.Entities;
using App.Infrastructure.Core;

namespace App.Main.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(GlobalContext dbContext) : base(dbContext)
        { }
    }
}
