using App.Data.DTOs;
using App.Data.Entities;
using App.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<AccountDTO> GetAsync(Guid id)
        {
            var entity = await _accountRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Account not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<AccountDTO>> GetByIdAsync(Guid id) // get projects by user id
        {
            var entityList = _accountRepository.Find(x => x.Id == id);
            if (entityList == null)
            {
                throw new Exception("No accounts found");
            }
            var modelList = new List<AccountDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<AccountDTO>> GetByCustIdAsync(Guid id) // get projects by user id
        {
            var entityList = _accountRepository.Find(x => x.CustomerId == id);
            if (entityList == null)
            {
                throw new Exception("No accounts found");
            }
            var modelList = new List<AccountDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAsync()
        {
            var query = await _accountRepository.GetAllAsync();
            var entity = query.Select(entity => entity.ToModel());
            return entity;
        }

        public async Task<Guid> CreateAsync(AccountDTO model)
        {
            var entity = new Account()
            {
                Id = Guid.NewGuid(),
                CustomerId = model.CustomerId,
                AccountNumber = model.AccountNumber
            };

            await _accountRepository.InsertAsync(entity);
            await _accountRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _accountRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Customer not found");
            }
            _accountRepository.Delete(entity);
            await _accountRepository.SaveAsync();
        }

        public async Task<AccountDTO> EditAsync(AccountDTO model)
        {
            var entity = await _accountRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Customer not found");
            }

            entity.Id = model.Id;
            entity.CustomerId = model.CustomerId;
            entity.AccountNumber = model.AccountNumber;
            _accountRepository.Update(entity);
            await _accountRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
