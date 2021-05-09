using App.Data.DTOs;
using App.Data.Entities;
using App.Main.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Main.Services
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _cacheRepository;
        public CaseService(ICaseRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public async Task<CaseDTO> GetAsync(Guid id)
        {
            var entity = await _cacheRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<CaseDTO>> GetByCustomerIdAsync(Guid id) // get projects by user id
        {
            var entityList = _cacheRepository.Find(x => x.CustomerId == id);
            if (entityList == null)
            {
                throw new Exception("No cases found");
            }
            var modelList = new List<CaseDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }

        public async Task<IEnumerable<CaseDTO>> GetByUserIdAsync(Guid id) // get projects by user id
        {
            var entityList = _cacheRepository.Find(x => x.UserId == id);
            if (entityList == null)
            {
                throw new Exception("No cases found");
            }
            var modelList = new List<CaseDTO>();
            foreach (var entity in entityList)
            {
                modelList.Add(entity.ToModel());
            }
            return modelList;
        }


        public async Task<IEnumerable<CaseDTO>> GetAllAsync()
        {
            var query = await _cacheRepository.GetAllAsync();
            var entity = query.Select(entity => entity.ToModel());
            return entity;
        }

        public async Task<Guid> CreateAsync(CaseDTO model)
        {
            var entity = new Case()
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                CustomerId = model.CustomerId,
                CreatedAt = model.CreatedAt,
                CaseNumber = model.CaseNumber,
                ActivityFlag = model.ActivityFlag,
                Description = model.Description
            };

            await _cacheRepository.InsertAsync(entity);
            await _cacheRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _cacheRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }
            _cacheRepository.Delete(entity);
            await _cacheRepository.SaveAsync();
        }

        public async Task<CaseDTO> EditAsync(CaseDTO model)
        {
            var entity = await _cacheRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Case not found");
            }

            entity.UserId = model.UserId;
            entity.CustomerId = model.CustomerId;
            entity.CreatedAt = model.CreatedAt;
            entity.CaseNumber = model.CaseNumber;
            entity.ActivityFlag = model.ActivityFlag;
            entity.Description = model.Description;
            _cacheRepository.Update(entity);
            await _cacheRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
