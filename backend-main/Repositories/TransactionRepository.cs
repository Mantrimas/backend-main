using App.Data.Entities;
using App.Infrastructure.Core;

namespace App.Main.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(GlobalContext dbContext) : base(dbContext)
        { }
    }
}
