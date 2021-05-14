using App.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public interface ICaseCommentService
    {
        Task<CaseCommentDTO> GetAsync(Guid id);
        Task<IEnumerable<CaseCommentDTO>> GetByCaseIdAsync(Guid id);
        Task<IEnumerable<CaseCommentDTO>> GetAllAsync();
        Task<Guid> CreateAsync(CaseCommentDTO model);
        Task DeleteAsync(Guid id);
        Task<CaseCommentDTO> EditAsync(CaseCommentDTO model);
    }
}
