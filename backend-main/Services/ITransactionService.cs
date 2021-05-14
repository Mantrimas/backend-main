using App.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public interface ITransactionService
    {
        Task<TransactionDTO> GetAsync(Guid id);
        Task<IEnumerable<TransactionDTO>> GetByIdAsync(Guid id);
        Task<IEnumerable<TransactionDTO>> GetByCustomerIdAsync(Guid id); // get projects by user id
        Task<IEnumerable<TransactionDTO>> GetAllAsync();
        Task<Guid> CreateAsync(TransactionDTO model);
        Task DeleteAsync(Guid id);
        Task<TransactionDTO> EditAsync(TransactionDTO model);
    }
}
