using App.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public interface ICaseService
    {
        Task<CaseDTO> GetAsync(Guid id);
        Task<IEnumerable<CaseDTO>> GetByCustomerIdAsync(Guid id);
        Task<IEnumerable<CaseDTO>> GetByUserIdAsync(Guid id);
        Task<IEnumerable<CaseDTO>> GetAllAsync();
        Task<Guid> CreateAsync(CaseDTO model);
        Task DeleteAsync(Guid id);
        Task<CaseDTO> EditAsync(CaseDTO model);
    }
}
