using App.Data.Entities;
using App.Infrastructure.Core;

namespace App.Main.Repositories
{
    public class CaseCommentRepository : GenericRepository<CaseComment>, ICaseCommentRepository
    {
        public CaseCommentRepository(GlobalContext dbContext) : base(dbContext)
        { }
    }
}
