using App.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public interface ICustomerService
    {
        Task<CustomerDTO> GetAsync(Guid id);
        Task<IEnumerable<CustomerDTO>> GetByIdAsync(Guid id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<Guid> CreateAsync(CustomerDTO model);
        Task DeleteAsync(Guid id);
        Task<CustomerDTO> EditAsync(CustomerDTO model);
    }
}
