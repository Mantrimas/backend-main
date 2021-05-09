using App.Data.Entities;
using App.Infrastructure.Core;

namespace App.Main.Repositories
{
    public class CaseRepository : GenericRepository<Case>, ICaseRepository
    {
        public CaseRepository(GlobalContext dbContext) : base(dbContext)
        { }
    }
}
