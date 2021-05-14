using App.Data.DTOs;
using App.Data.Entities;
using App.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionDTO> GetAsync(Guid id)
        {
            var entity = await _transactionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<TransactionDTO>> GetByIdAsync(Guid id) // get projects by user id
        {
            var entityList = _transactionRepository.Find(x => x.Id == id);
            if (entityList == null)
            {
                throw new Exception("No customers found");
            }
            var modelList = new List<TransactionDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<TransactionDTO>> GetByCustomerIdAsync(Guid id) // get projects by user id
        {
            var entityList = _transactionRepository.Find(x => x.CustomerId == id);
            if (entityList == null)
            {
                throw new Exception("No comments found");
            }
            var modelList = new List<TransactionDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllAsync()
        {
            var query = await _transactionRepository.GetAllAsync();
            var entity = query.Select(entity => entity.ToModel());
            return entity;
        }

        public async Task<Guid> CreateAsync(TransactionDTO model)
        {
            var entity = new Transaction()
            {
                Id = Guid.NewGuid(),
                AccountId = model.AccountId,
                CustomerId = model.CustomerId,
                Amount = model.Amount,
                Details = model.Details,
                Date = model.Date,
                TransactionType = model.TransactionType
            };

            await _transactionRepository.InsertAsync(entity);
            await _transactionRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _transactionRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }
            _transactionRepository.Delete(entity);
            await _transactionRepository.SaveAsync();
        }

        public async Task<TransactionDTO> EditAsync(TransactionDTO model)
        {
            var entity = await _transactionRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Comment not found");
            }

            entity.Id = model.Id;
            entity.AccountId = model.AccountId;
            entity.CustomerId = model.CustomerId;
            entity.Amount = model.Amount;
            entity.Details = model.Details;
            entity.Date = model.Date;
            entity.TransactionType = model.TransactionType;
            _transactionRepository.Update(entity);
            await _transactionRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
