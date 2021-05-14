using App.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAsync(Guid id);
        Task<IEnumerable<AccountDTO>> GetByIdAsync(Guid id);
        Task<IEnumerable<AccountDTO>> GetByCustIdAsync(Guid id);
        Task<IEnumerable<AccountDTO>> GetAllAsync();
        Task<Guid> CreateAsync(AccountDTO model);
        Task DeleteAsync(Guid id);
        Task<AccountDTO> EditAsync(AccountDTO model);
    }
}
