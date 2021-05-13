using App.Data.DTOs;
using App.Data.Entities;
using App.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDTO> GetAsync(Guid id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<CustomerDTO>> GetByIdAsync(Guid id) // get projects by user id
        {
            var entityList = _customerRepository.Find(x => x.Id == id);
            if (entityList == null)
            {
                throw new Exception("No cases found");
            }
            var modelList = new List<CustomerDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            var query = await _customerRepository.GetAllAsync();
            var entity = query.Select(entity => entity.ToModel());
            return entity;
        }

        public async Task<Guid> CreateAsync(CustomerDTO model)
        {
            var entity = new Customer()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                Citizenship = model.Citizenship,
                NationalId = model.NationalId,
                BirthDate = model.BirthDate,
                CustomerType = model.CustomerType
            };

            await _customerRepository.InsertAsync(entity);
            await _customerRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }
            _customerRepository.Delete(entity);
            await _customerRepository.SaveAsync();
        }

        public async Task<CustomerDTO> EditAsync(CustomerDTO model)
        {
            var entity = await _customerRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }

            entity.Id = model.Id;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Phone = model.Phone;
            entity.Email = model.Email;
            entity.Address = model.Address;
            entity.Citizenship = model.Citizenship;
            entity.NationalId = model.NationalId;
            entity.BirthDate = model.BirthDate;
            entity.CustomerType = model.CustomerType;
            _customerRepository.Update(entity);
            await _customerRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
